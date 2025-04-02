using System;
using BowSystem.Scripts.Service;
using Spine.Unity;
using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public class PlayerBow : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        [field: SerializeField] public Transform Tip { get; private set; }
        [field: SerializeField] public float Power { get; private set; }
        [field: SerializeField] public float TimeBetweenShoots { get; private set; }
        
        public IFactory Factory { get; private set; }
        public IInput Input { get; private set; }

        public Vector2 Velocity => (Camera.main.ScreenToWorldPoint(Input.AimPosition) - transform.position) * Power;
        
        public event Action TryingToShoot;
        public event Action StartedAiming;
        public event Action EndedAiming;

        
        public void Construct(IFactory factory, IInput input)
        {
            Factory = factory;
            Input = input;
        }
        
        public void TryShoot()
        {
            TryingToShoot?.Invoke();
        }

        public void Shoot()
        {
            var position = Tip.position;

            var arrow = Factory.CreateArrow(position, Velocity);
        }

        public void StartAiming() => StartedAiming?.Invoke();
        public void EndAiming() => EndedAiming?.Invoke();
    }
}