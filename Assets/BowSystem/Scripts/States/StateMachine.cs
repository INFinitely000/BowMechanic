using System;
using System.Collections.Generic;
using BowSystem.Scripts.Service;

namespace BowSystem.Scripts.States
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _states;

        public Services Services { get; private set; }
        public IState Current { get; private set; }
        
        public StateMachine(Services services)
        {
            Services = services;

            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, 
                    Services.Single<IFactory>(), 
                    Services.Single<IInput>())
            };
        }

        public void Entry<TState>() where TState : class, IState
        {
            Current?.Exit();

            Current = _states[typeof(TState)];
            
            Current?.Entry();
        }
    }
}