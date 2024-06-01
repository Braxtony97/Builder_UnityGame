using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Builder_mainProject._1Scripts._1DI
{
    internal class DIRegistration
    {
        public Func<DIContainer, object> Factory { get; set; }  
        public bool IsSingletone { get; set; }
        public object Instance { get; set; }
    }
}
