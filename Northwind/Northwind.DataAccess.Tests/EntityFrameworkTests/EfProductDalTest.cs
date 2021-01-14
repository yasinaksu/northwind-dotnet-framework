using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;

namespace Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EfProductDalTest
    {
        [TestMethod]
        public void Get_list_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var products = productDal.GetList();
            Assert.AreEqual(79, products.Count);
        }

        [TestMethod]
        public void Get_list_with_parameters_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var products = productDal.GetList(x=>x.CategoryId==1);
            Assert.AreEqual(14, products.Count);
        }
    }
}
