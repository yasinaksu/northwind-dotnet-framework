using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EfCategoryDalTest
    {
        [TestMethod]
        public void Get_list_returns_all_categories()
        {
            var categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList();
            Assert.AreEqual(8, result.Count);
        }
    }
}
