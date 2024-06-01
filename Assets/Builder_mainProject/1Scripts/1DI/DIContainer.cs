
using System;
using System.Collections.Generic;

namespace Assets.Builder_mainProject._1Scripts._1DI
{
    public class DIContainer
    {
        
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string, Type), DIRegistration> _registrations = new();

        public DIContainer(DIContainer parentContainer) { 
            _parentContainer = parentContainer;
        }
    }
}

