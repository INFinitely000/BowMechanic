using BowSystem.Scripts.Service;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BowSystem.Scripts.States
{
    public class BootstrapState : IState
    {
        private const string MainSceneName = "Main";
        
        private readonly StateMachine stateMachine;
        private readonly IFactory factory;
        private readonly IInput input;

        public BootstrapState(StateMachine stateMachine, IFactory factory, IInput input)
        {
            this.stateMachine = stateMachine;
            this.factory = factory;
            this.input = input;
        }
        
        
        public void Entry()
        {   
            var operation = SceneManager.LoadSceneAsync(MainSceneName);
                operation.completed += ConstructLevel;
        }

        private void ConstructLevel(AsyncOperation obj)
        {
            var levelData = Object.FindObjectOfType<LevelData>();
            
            var mainPlayer = factory.CreateMainPlayer(levelData.PlayerSpawnpoint.position);
                mainPlayer.GetComponentInChildren<MouseIKTarget>().Construct(input);
                mainPlayer.GetComponentInChildren<PlayerBow>().Construct(factory, input);
        }

        public void Exit()
        {
            
        }
    }
}