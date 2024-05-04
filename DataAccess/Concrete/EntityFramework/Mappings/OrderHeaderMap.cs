using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderHeaderMap : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Status).HasDefaultValueSql("1");

            builder.Property(x => x.TotalAmount).HasPrecision(18,2);

            builder.HasOne(x => x.Customer).WithMany(y => y.OrderHeaders)
                .HasForeignKey(x => x.CustomerId);

            //kullanıcı siperişlerini eklemedim çünkü user classı core katmanında olduğu için entity referansı vermek doğru olmaz.
        }
    }
}
