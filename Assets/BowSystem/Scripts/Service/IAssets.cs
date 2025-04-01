using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public interface IAssets : IService
    {
        public GameObject Get(string objectName);
    }
}