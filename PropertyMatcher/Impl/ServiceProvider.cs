using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Impl
{
    /// <summary>
    /// Service provider. Usually Dependency injection.
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        /// <summary>
        /// Gets service for the given type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return Activator.CreateInstance(serviceType);
        }
    }
}
