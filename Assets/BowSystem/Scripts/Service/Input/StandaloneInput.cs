using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class StandaloneInput : IInput
    {
        public Vector2 AimPosition => Input.mousePosition;

        public InputType IsShoot
        {
            get
            {
                if (Input.GetButtonDown("Fire1")) return InputType.Down;
                if (Input.GetButton("Fire1")) return InputType.Press;
                if (Input.GetButtonUp("Fire1")) return InputType.Up;

                return InputType.None;
            }
        }

        public InputType IsReload
        {
            get
            {
                if (Input.GetButtonDown("Reload")) return InputType.Down;
                if (Input.GetButton("Reload")) return InputType.Press;
                if (Input.GetButtonUp("Reload")) return InputType.Up;

                return InputType.None;
            }
        }
    }
}