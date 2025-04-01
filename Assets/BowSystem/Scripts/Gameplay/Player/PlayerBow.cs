using System;
using System.Collections;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Events;
using Event = Spine.Event;

namespace BowSystem.Scripts.Service
{
    public class PlayerBow : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        [field: SerializeField] public Transform Tip { get; private set; }
        [field: SerializeField] public float Power { get; private set; }
        [field: SerializeField] public float TimeBetweenShoots { get; private set; }
        
        public IFactory Factory { get; private set; }
        public IInput Input { get; private set; }
        
        public event Action TryingToShoot;
        public bool isAim;

        public void Construct(IFactory factory, IInput input)
        {
            Factory = factory;
            Input = input;
        }
        
        public bool TryShoot()
        {
            TryingToShoot?.Invoke();
            
            return true;
        }

        public void Shoot()
        {
            var position = Tip.position;
            var velocity = (Camera.main.ScreenToWorldPoint(Input.AimPosition) - transform.position) * Power;

            var arrow = Factory.CreateArrow(position, velocity);
        }
    }
}