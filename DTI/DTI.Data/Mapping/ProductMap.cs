using DTI.Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasColumnType("varchar(800)");

            builder.Property(x => x.Price)
                 .IsRequired()
                 .HasColumnType("decimal");

            builder.Property(x => x.Qtd)
               .IsRequired()
               .HasColumnType("int");
        }
    }
}
