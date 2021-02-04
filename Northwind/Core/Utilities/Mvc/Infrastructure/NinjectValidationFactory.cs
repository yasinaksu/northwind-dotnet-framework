using Core.Utilities.Messages;
using FluentValidation;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mvc.Infrastructure
{
    public class NinjectValidationFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;
        public NinjectValidationFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException(CustomErrorMessages.TypeDoesNotSubclassValidatorBase);
            }
            return (IValidator)_kernel.TryGet(validatorType);
        }        
    }
}
