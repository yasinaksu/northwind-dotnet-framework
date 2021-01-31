using Core.Entities.Concrete;
using Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IAuthService
    {
        void Logout();
        void CreateAuthCookie(User user);
        User Register(UserForRegisterDto userForRegisterDto);
        User Login(UserForLoginDto userForLoginDto);
        void UserExist(string email);
    }
}
