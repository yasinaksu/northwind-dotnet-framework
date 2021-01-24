using Core.Utilities.Messages;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory(INinjectModule ninjectModule)
        {
            _kernel = new StandardKernel(ninjectModule);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("{0} {1}", CustomErrorMessages.NoControllerFound, requestContext.HttpContext.Request.Path));
            }
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(CustomErrorMessages.TypeDoesNotSubclassControllerBase);
            }

            return (IController)_kernel.Get(controllerType);
        }
    }
}
