using Core.CrossCuttingConcerns.Security.Hashing;
using Core.CrossCuttingConcerns.Security.Web;
using Core.Entities.Concrete;
using Northwind.Business.Abstract;
using Northwind.Business.Constrants;
using Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public void CreateAuthCookie(User user)
        {
            var claims = _userService.GetClaims(user);
            AuthenticationHelper.CreateAuthCookie(
                user.Id,
                user.Email,
                user.Email,
                DateTime.Now.AddDays(15),
                claims.Select(x=>x.Name).ToArray(),
                false,
                user.FirstName,
                user.LastName);
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                throw new Exception(Messages.UserNotFound);
            }

            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt);

            if (!result)
            {
                throw new Exception(Messages.PasswordError);
            }

            return userToCheck;
        }

        public void Logout()
        {
            AuthenticationHelper.Logout();
        }

        public User Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return user;
        }

        public void UserExist(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                throw new Exception(Messages.UserAlreadyExist);
            }
        }
    }
}
