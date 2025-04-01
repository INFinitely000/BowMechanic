using BowSystem.Scripts.Gameplay;
using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class Factory : IFactory
    {
        private const string MainPlayerName = "MainPlayer";
        private const string ArrowName = "Arrow";
        
        public readonly IAssets Assets;
        public readonly IInput Input;


        public Factory(IAssets assets, IInput input)
        {
            Assets = assets;
            Input = input;
        }

        public GameObject Create(string objectName)
        {
            var prefab = Assets.Get(objectName);

            var createdObject = Object.Instantiate(prefab);

            return createdObject;
        }

        public MainPlayer CreateMainPlayer(Vector3 position)
        {
            var player = Create(MainPlayerName).GetComponent<MainPlayer>();
                player.transform.position = position;
                player.Construct(Input);

            return player;
        }

        public Arrow CreateArrow(Vector3 position, Vector2 velocity)
        {
            var arrow = Create(ArrowName).GetComponent<Arrow>();
                arrow.transform.position = position;
                arrow.Rigidbody.velocity = velocity;
                arrow.transform.rotation = Quaternion.Euler(Vector3.forward * -Vector2.SignedAngle(velocity, Vector2.right));

            return arrow;
        }
    }
}