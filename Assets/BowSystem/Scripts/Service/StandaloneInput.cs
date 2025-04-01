using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class StandaloneInput : IInput
    {
        public Vector2 AimPosition => Input.mousePosition;
        public bool IsShoot => Input.GetButtonUp("Fire1");
        public bool IsAim => Input.GetButton("Fire1");
        public bool IsReload => Input.GetButtonDown("Reload"); 
    }
}