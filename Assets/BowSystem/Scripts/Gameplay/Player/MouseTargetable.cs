using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public abstract class MouseTargetable : MonoBehaviour
    {
        public abstract void TargetTo(Vector2 position);    
    }
}