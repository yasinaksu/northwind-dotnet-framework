using Core.CrossCuttingConcerns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Core.Extensions
{
    public static class FormsAuthenticationTicketExtension
    {
        public static Identity FormsAuthTicketToIdentity(this FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = Convert.ToInt32(ticket.UserData.Split('|')[4]),
                Name = ticket.Name,
                Email = ticket.UserData.Split('|')[0],
                Roles = ticket.UserData.Split('|')[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
                FirstName = ticket.UserData.Split('|')[2],
                LastName = ticket.UserData.Split('|')[3],
                AuthenticationType = "Forms",
                IsAuthenticated = true
            };
            return identity;
        }
    }
}
