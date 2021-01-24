using Core.Aspects.Postsharp.CacheAspects;
using Core.Aspects.Postsharp.LogAspects;
using Core.Aspects.Postsharp.TransactionAspects;
using Core.Aspects.Postsharp.ValidationAspects;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Northwind.Business.Concrete.Managers
{

    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator), AspectPriority = 2)]
        [CacheRemoveAspect(typeof(MemoryCacheManager), AspectPriority = 3)]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager), 60, AspectPriority = 3)]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidator), AspectPriority = 1)]
        [CacheRemoveAspect(typeof(MemoryCacheManager), AspectPriority = 2)]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
