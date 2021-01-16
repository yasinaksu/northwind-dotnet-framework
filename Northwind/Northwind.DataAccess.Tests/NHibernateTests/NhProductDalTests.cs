using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Tests.NHibernateTests
{
    /// <summary>
    /// Summary description for NhProductDal
    /// </summary>
    [TestClass]
    public class NhProductDalTests
    {
        [TestMethod]
        public void Get_list_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var products = productDal.GetList();
            Assert.AreEqual(79, products.Count);
        }

        [TestMethod]
        public void Get_list_with_parameters_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var products = productDal.GetList(x => x.CategoryId == 1);
            Assert.AreEqual(14, products.Count);
        }
    }
}
