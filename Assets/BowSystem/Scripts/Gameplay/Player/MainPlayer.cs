using BowSystem.Scripts.Service;
using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public class MainPlayer : MonoBehaviour
    {
        [field: SerializeField] public PlayerBow Bow { get; private set; }
        [field: SerializeField] public MouseTargetable Targetable { get; private set; }

        public IInput Input { get; private set; }
        

        public void Construct(IInput input)
        {
            Input = input;
        }
        
        
        private void Update()
        {
            if (Time.time < 0.5f) return;
            
            switch (Input.IsShoot)
            {
                case InputType.Down: Bow.StartAiming(); 
                    break;
                
                case InputType.Up: Bow.TryShoot(); Bow.EndAiming();
                    break;
            }

            var targetPosition = Camera.main.ScreenToWorldPoint(Input.AimPosition);
            
            Targetable.TargetTo( Camera.main.ScreenToWorldPoint(Input.AimPosition) );
        }
    }
}