using Core.DataAccess.NHibernate;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private readonly NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDto> GetProductDtos()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.CategoryId
                             select new ProductDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName
                             };
                return result.ToList();
            }
        }
    }
}
