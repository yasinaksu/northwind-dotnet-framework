using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.Business.Concrete.Managers;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Tests.ManagersTests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Add_fluent_validation_check()
        {
            var mock = new Mock<IProductDal>();
            var productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
