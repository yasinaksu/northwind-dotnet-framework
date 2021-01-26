using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public static Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = GetId(ticket),
                Name = ticket.Name,
                Email = GetEmail(ticket),
                Roles = GetTRoles(ticket),
                FirstName = GetFirstName(ticket),
                LastName = GetLastName(ticket),
                AuthenticationType = GetAuthType(),
                IsAuthenticated = GetIsAuthenticated()
            };
            return identity;
        }

        private static int GetId(FormsAuthenticationTicket ticket)
        {
            return Convert.ToInt32(ticket.UserData.Split('|')[4]);
        }

        private static string GetEmail(FormsAuthenticationTicket ticket)
        {
            return ticket.UserData.Split('|')[0];
        }

        private static string[] GetTRoles(FormsAuthenticationTicket ticket)
        {
            return ticket.UserData.Split('|')[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string GetFirstName(FormsAuthenticationTicket ticket)
        {
            return ticket.UserData.Split('|')[2];
        }

        private static string GetLastName(FormsAuthenticationTicket ticket)
        {
            return ticket.UserData.Split('|')[3];
        }

        private static string GetAuthType()
        {
            return "Forms";
        }

        private static bool GetIsAuthenticated()
        {
            return true;
        }
    }
}
