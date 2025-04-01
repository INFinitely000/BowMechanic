using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public interface IInput : IService
    {
        public Vector2 AimPosition { get; }
        public bool IsShoot { get; }
        public bool IsAim { get; }
        public bool IsReload { get; }
    }
}