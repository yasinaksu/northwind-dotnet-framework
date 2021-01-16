using FluentNHibernate.Mapping;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            Schema(@"dbo");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryId");

            Map(x => x.CategoryName).Column(@"CategoryName");
        }
    }
}
