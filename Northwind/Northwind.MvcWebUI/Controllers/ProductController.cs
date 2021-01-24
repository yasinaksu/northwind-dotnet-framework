using Northwind.Business.Abstract;
using Northwind.Entities.Concrete;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductIndexViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            var product = new Product
            {
                CategoryId = 1,
                ProductName = "Log Demo",
                UnitsInStock = -1
            };
            _productService.Add(product);
            return "Product/Add works";
        }

        public string TransactionTest()
        {
            var product1 = new Product
            {
                CategoryId = 1,
                ProductName = "Transaction Demo-2",
                UnitsInStock = 10,
                UnitPrice = 10
            };
            var product2 = new Product
            {
                ProductId = 79,
                CategoryId = 1,
                ProductName = "Transaction Demo-1",
                UnitsInStock = 1,
                UnitPrice = 10
            };
            _productService.TransactionalOperation(product1, product2);
            return "Done";
        }
    }
}