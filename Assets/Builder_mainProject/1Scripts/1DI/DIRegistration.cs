using System;

namespace Assets.Builder_mainProject._1Scripts._1DI
{
    public class DIRegistration
    {
        public Func<DIContainer, object> Factory { get; set; }  
        public bool IsSingletone { get; set; }
        public object Instance { get; set; }
    }
}
