using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation
{
    public static class ServiceProviderActivator
    {
        private static IServiceProvider _provider;

        public static void SetUpProvider(IServiceProvider provider)
        {
            _provider = provider;
        }
        public static IServiceProvider Provider => _provider;
    }
}
