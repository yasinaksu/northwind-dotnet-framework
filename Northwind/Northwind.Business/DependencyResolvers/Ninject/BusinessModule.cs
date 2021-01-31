using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.NHibernate;
using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete.Managers;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<IAuthService>().To<AuthManager>().InSingletonScope();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>)).InSingletonScope();
            Bind<DbContext>().To<NorthwindContext>().InSingletonScope();
            Bind<NHibernateHelper>().To<SqlServerHelper>().InSingletonScope();
        }
    }
}
