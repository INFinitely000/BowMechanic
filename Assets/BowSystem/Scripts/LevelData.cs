using UnityEngine;

namespace BowSystem.Scripts
{
    public class LevelData : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerSpawnpoint  { get; private set; }
    }
}