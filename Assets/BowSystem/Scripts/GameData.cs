using UnityEngine;

namespace BowSystem.Scripts
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Infrastructure/GameData")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField] public Assets Assets { get; private set; }
        [field: Header("ArrowData")]
        [field: SerializeField] public float ExplosionRadius { get; private set; }
        [field: SerializeField] public float ExplosionPower { get; private set; }
    }
}