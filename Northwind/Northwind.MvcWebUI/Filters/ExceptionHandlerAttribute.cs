using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Filters
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            if (exception.GetType() == typeof(ValidationException))
            {
                var validationErrors = ((ValidationException)exception).Errors;
                filterContext.Controller.ViewData.ModelState.AddModelError("ValidationException", string.Join(",", validationErrors.Select(x => x.ErrorMessage).ToArray()));
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData
                };
            }
            else
            {
                filterContext.Controller.ViewData.ModelState.AddModelError("CustomException", exception);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData
                };
            }
        }
    }
}