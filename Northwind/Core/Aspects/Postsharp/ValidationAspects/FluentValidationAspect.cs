using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Messages;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!typeof(IValidator).IsAssignableFrom(_validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
