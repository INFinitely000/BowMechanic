using BowSystem.Scripts.Gameplay;
using BowSystem.Scripts.Gameplay.Player;
using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public interface IFactory : IService
    {
        public GameObject Create(string objectName);
        public MainPlayer CreateMainPlayer(Vector3 position);
        public Arrow CreateArrow(Vector3 position, Vector2 velocity);
    }
}