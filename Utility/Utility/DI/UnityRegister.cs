

using Microsoft.Practices.Unity.Configuration;

namespace Utility.UnityRegister
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Practices.Unity;
    using System.Configuration;

    public class UnityRegister
    {
        private static IList<string> ListRegisteredAssemblies = new List<string>() 
        { 
             "Utility",
        };

        public static void RegisterTypes(IUnityContainer container)
        {
            var types = AllClasses.FromLoadedAssemblies().Where(t => ListRegisteredAssemblies.Contains(t.Namespace));

            container.RegisterTypes(types);
        }
    }
}
