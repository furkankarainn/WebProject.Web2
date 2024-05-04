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
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Status).HasDefaultValueSql("1");

            builder.Property(x => x.Amount).HasPrecision(18, 2);

            builder.HasOne(x => x.Product).WithMany(y => y.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.OrderHeader).WithMany(y => y.OrderDetails)
                .HasForeignKey(x => x.OrderHeaderId);
        }
    }
}
