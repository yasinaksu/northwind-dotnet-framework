using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T Get<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.TryGet<T>();
        }
    }
}
