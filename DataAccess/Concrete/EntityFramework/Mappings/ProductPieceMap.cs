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
    public class ProductPieceMap : IEntityTypeConfiguration<ProductPiece>
    {
        public void Configure(EntityTypeBuilder<ProductPiece> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Status).HasDefaultValueSql("1");

            builder.HasOne(x => x.Product).WithMany(y => y.ProductPieces)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Piece).WithMany(y => y.ProductPieces)
                .HasForeignKey(x => x.PieceId);
        }
    }
}
