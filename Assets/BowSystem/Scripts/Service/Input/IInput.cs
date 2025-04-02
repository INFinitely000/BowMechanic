using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public interface IInput : IService
    {
        public Vector2 AimPosition { get; }
        public InputType IsShoot { get; }
        public InputType IsReload { get; }
    }
}