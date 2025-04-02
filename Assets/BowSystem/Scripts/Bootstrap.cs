using BowSystem.Scripts.Service;
using BowSystem.Scripts.States;
using UnityEngine;

namespace BowSystem.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap _instance;
        
        [field: SerializeField] public GameData GameData { get; private set; }
        
        public Services Services { get; private set; }
        public StateMachine StateMachine { get; private set; }
        
        private void Awake() => Initialize();

        private void Initialize()
        {
            if (TryCreateInstance() == false) return;
            
            Services = new Services();

            RegistServices();
            
            StateMachine = new StateMachine(Services);
            StateMachine.Entry<BootstrapState>();
        }

        private bool TryCreateInstance()
        {
            if (_instance)
            {
                Destroy(gameObject);

                return false;
            }
            else
            {
                _instance = this;
                
                DontDestroyOnLoad(transform);

                return true;
            }
        }

        private void RegistServices()
        {
            Services.Register<IAssets>(GameData.Assets); 
            Services.Register<IInput>(new StandaloneInput());
            Services.Register<IFactory>(new Factory(
                assets: Services.Single<IAssets>(), 
                input: Services.Single<IInput>(), GameData));
        }
    }
}