using System;
using BowSystem.Scripts.Service;
using ProjectTools;
using UnityEngine;

namespace BowSystem.Scripts
{
    [CreateAssetMenu(fileName = "Assets", menuName = "Infrastructure/Assets")]
    public class Assets : ScriptableObject, IAssets
    {
        [SerializeField] private SerializableDictionary<string, GameObject> prefabs;

        public GameObject Get(string objectName) => 
            prefabs[objectName];
    }
}