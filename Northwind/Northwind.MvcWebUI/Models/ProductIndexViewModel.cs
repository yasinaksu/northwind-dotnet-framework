using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.MvcWebUI.Models
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
    }
}