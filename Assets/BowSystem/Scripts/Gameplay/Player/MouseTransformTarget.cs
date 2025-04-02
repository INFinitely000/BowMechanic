using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public class MouseTransformTarget : MouseTargetable
    {
        public override void TargetTo(Vector2 position)
        {
            var angle = -Vector2.SignedAngle(position - (Vector2)transform.position, Vector2.right);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}