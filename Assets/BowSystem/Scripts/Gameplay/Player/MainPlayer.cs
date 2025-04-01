using System;
using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class MainPlayer : MonoBehaviour
    {
        [field: SerializeField] public PlayerBow Bow { get; private set; }

        public IInput Input { get; private set; }
        

        public void Construct(IInput input)
        {
            Input = input;
        }
        
        
        private void Update()
        {
            Bow.isAim = Input.IsAim;

            if (Input.IsShoot) Bow.TryShoot();

            var targetPosition = Camera.main.ScreenToWorldPoint(Input.AimPosition);
            
            transform.rotation =
                Quaternion.Euler(Vector3.forward * -Vector2.SignedAngle(targetPosition - transform.position, Vector2.right));
        }
    }
}