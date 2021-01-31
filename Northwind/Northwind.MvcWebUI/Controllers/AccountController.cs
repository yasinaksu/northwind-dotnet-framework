using Core.CrossCuttingConcerns.Security.Web;
using Northwind.Business.Abstract;
using Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        // GET: Account
        public string Login(UserForLoginDto userForLoginDto)
        {
            var user = _authService.Login(userForLoginDto);
            if (user == null)
            {
                return "kullanıcı bulunamadı";
            }
            _authService.CreateAuthCookie(user);
            return "Authenticated successfully";
        }

        public string Logout()
        {
            _authService.Logout();
            return "User is signout";
        }
    }
}