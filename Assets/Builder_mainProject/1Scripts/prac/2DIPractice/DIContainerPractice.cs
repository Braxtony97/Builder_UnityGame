using System;
using System.Collections.Generic;

namespace Assets.Builder_mainProject._1Scripts._2DIPractice
{
    public class DIContainerPractice
    {
        private readonly Dictionary<Type, Func<object>> _registrations = new();

        public void Register<T> (Func<object> factory)
        {
            _registrations[typeof (T)] = factory;
        }

        public T Resolve<T>()
        {
            return (T)_registrations[typeof (T)].Invoke();
        }
    }
}
