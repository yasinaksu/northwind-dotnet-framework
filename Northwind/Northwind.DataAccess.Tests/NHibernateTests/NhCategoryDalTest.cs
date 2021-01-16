using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NhCategoryDalTest
    {
        [TestMethod]
        public void Get_list_returns_all_categories()
        {
            var categoryDal = new NhCategoryDal(new SqlServerHelper());
            var result = categoryDal.GetList();
            Assert.AreEqual(8, result.Count);
        }
    }
}
