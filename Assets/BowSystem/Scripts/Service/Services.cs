using System;
using System.Collections.Generic;

namespace BowSystem.Scripts.Service
{
    public class Services
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        
        public void Register<TService>(TService service) where TService : IService
        {
            if (_services.ContainsKey(typeof(TService))) return;
            
            _services.Add(typeof(TService), service);
        }

        public TService Single<TService>() where TService : IService
        {
            return (TService)_services[typeof(TService)];
        }
    }
}