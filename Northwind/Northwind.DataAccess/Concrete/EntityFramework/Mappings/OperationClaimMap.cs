using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimMap : EntityTypeConfiguration<OperationClaim>
    {
        public OperationClaimMap()
        {
            ToTable(@"OperationClaims", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
        }
    }
}
