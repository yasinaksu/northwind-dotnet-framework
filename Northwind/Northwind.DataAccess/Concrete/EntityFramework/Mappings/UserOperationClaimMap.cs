using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserOperationClaimMap : EntityTypeConfiguration<UserOperationClaim>
    {
        public UserOperationClaimMap()
        {
            ToTable(@"UserOperationClaims", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");
            Property(x => x.UserId).HasColumnName("UserId");
        }
    }
}
