using Core.CrossCuttingConcerns.Security.Web;
using Core.Extensions;
using Core.Utilities.Mvc.Infrastructure;
using Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                if (authCookie == null)
                {
                    return;
                }

                var encryptedTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encryptedTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encryptedTicket);
                //var securityUtilities = new SecurityUtilities();
                //var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);

                var identity = ticket.ToIdentity();
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {

            }
        }
    }
}
