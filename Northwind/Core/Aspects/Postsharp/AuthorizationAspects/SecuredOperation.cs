using Core.Utilities.Messages;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        /// <summary>
        /// you should enter roles by separating with comma ","
        /// </summary>
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var roles = Roles.Split(',');
            var isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }

            if (!isAuthorized)
            {
                throw new SecurityException(AspectMessages.UnAuthorized);
            }

        }
    }
}
