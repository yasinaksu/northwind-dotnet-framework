using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(int id, string userName, string email, DateTime expiration, string[] roles, bool rememberMe, string firstName, string lastName)
        {
            var userData = CreateUserData(email, roles, firstName, lastName, id);
            var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, userData);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
        }

        private static string CreateUserData(string email, string[] roles, string firstName, string lastName, int id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (roles.Last() != roles[i])
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");

            stringBuilder.Append(firstName);
            stringBuilder.Append("|");

            stringBuilder.Append(lastName);
            stringBuilder.Append("|");

            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
