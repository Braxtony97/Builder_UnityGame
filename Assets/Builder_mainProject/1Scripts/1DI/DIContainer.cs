using System;
using System.Collections.Generic;

namespace Assets.Builder_mainProject._1Scripts._1DI
{
    public class DIContainer
    {
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string, Type), DIRegistration> _registrations = new();
        private readonly HashSet<(string, Type)> _resolutions = new();

        public DIContainer(DIContainer parentContainer = null) { 
            _parentContainer = parentContainer;
        }

        #region Registration
        public void RegisterSingletone<T>(Func<DIContainer, T> factory)
        {
            RegisterSingletone(null, factory);
        }

        public void RegisterSingletone<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, true);
        }

        public void RegisterTransient<T>(Func<DIContainer, T> factory)
        {
            RegisterTransient(null, factory);
        }

        public void RegisterTransient<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, false);
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(null, instance);
        }

        public void RegisterInstance<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));

            if (_registrations.ContainsKey(key))
            {
                throw new Exception($"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registred");
            }

            _registrations[key] = new DIRegistration()
            {
                Instance = instance,
                IsSingletone = true
            };
        }

        private void Register<T>((string, Type) key, Func<DIContainer, T> factory, bool isSingletone) 
        {
            if (_registrations.ContainsKey(key))
            {
                throw new Exception($"DI: Factory with tag {key.Item1} and type {key.Item2.FullName} has already registred");
            }

            _registrations[key] = new DIRegistration()
            {
                Factory = c => factory(c),
                IsSingletone = isSingletone
            };
        }

        #endregion

        #region Resolve

        public T Resolve<T>(string tag = null)
        {
            var key = (tag, typeof (T));

            if (_resolutions.Contains(key))
            {
                throw new Exception($"Cyclic dependecy for tag {tag} and type {key.Item2.FullName}");
                // Если уже запрашивали с таким key, то ошибка
            }
            _resolutions.Add(key);

            try {
                if (_registrations.TryGetValue(key, out var registration))
                {
                    if (registration.IsSingletone)
                    {
                        if (registration.Instance == null && registration.Factory != null)
                        {
                            registration.Instance = registration.Factory(this);
                        }

                        return (T)registration.Instance;
                    }
                    return (T)registration.Factory(this);
                }

                if (_parentContainer != null)
                {
                    return _parentContainer.Resolve<T>();
                }
            }
            finally {
                _resolutions.Remove(key);
            }

            throw new Exception($"Couldn't find dependecy for tag {tag} and type {key.Item2.FullName}");
        }

        #endregion
    }
}

