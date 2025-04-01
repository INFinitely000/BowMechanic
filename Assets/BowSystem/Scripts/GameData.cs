using UnityEngine;

namespace BowSystem.Scripts
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Infrastructure/GameData")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField] public Assets Assets { get; private set; }
    }
}