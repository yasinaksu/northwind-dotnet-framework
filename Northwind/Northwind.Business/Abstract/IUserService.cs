using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);

        User GetByMail(string email);

        List<OperationClaim> GetClaims(User user);
    }
}
