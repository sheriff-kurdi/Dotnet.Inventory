using System;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kurdi.Inventory.Infrastructure.Configurations.Entities.ProductsAggregate;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Sku);

        builder.HasOne(product => product.Category).WithMany().HasForeignKey("CategoryName");
        builder.Property(product => product.CategoryName).IsRequired();

        builder.HasMany(product => product.ProductDetails).WithOne().HasForeignKey("Sku");

        builder.Property(product => product.SupplierIdentity).IsRequired();
        builder.Property(product => product.Activation).IsRequired();


        builder.OwnsOne(product => product.ProductPrices);
        builder.OwnsOne(product => product.ProductPrices).Property(price => price.CostPrice).IsRequired().HasColumnName("cost_price");
        builder.OwnsOne(product => product.ProductPrices).Property(price => price.SellingPrice).IsRequired().HasColumnName("selling_price");
        builder.OwnsOne(product => product.ProductPrices).Property(price => price.IsDiscounted).IsRequired().HasColumnName("is_discounted");
        builder.OwnsOne(product => product.ProductPrices).Property(price => price.Discount).IsRequired().HasColumnName("discount");

        builder.OwnsOne(product => product.ProductQuantity);
        builder.OwnsOne(product => product.ProductQuantity).Property(price => price.TotalStock).IsRequired().HasColumnName("total_stock");
        builder.OwnsOne(product => product.ProductQuantity).Property(price => price.AvailableStock).IsRequired().HasColumnName("available_stock");
        builder.OwnsOne(product => product.ProductQuantity).Property(price => price.ReservedStock).IsRequired().HasColumnName("reserved_stock");

        builder.OwnsOne(product => product.TimeStamps);
        builder.OwnsOne(product => product.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
        builder.OwnsOne(product => product.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasDefaultValue(null).HasColumnName("updated_at");
        builder.OwnsOne(product => product.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasDefaultValue(null).HasColumnName("deleted_at");



        builder.HasData(
                new Product
                {
                    Sku = "1",
                    SupplierIdentity = 0,
                    Activation = true,
                    CategoryName = "MEN",
                },
                new Product
                {
                    Sku = "2",
                    SupplierIdentity = 0,
                    Activation = true,
                    CategoryName = "WOMEN",
                }
            );

        builder.OwnsOne(product => product.ProductQuantity).HasData(
                     new { ProductSku = "1", TotalStock = 1000, AvailableStock = 800, ReservedStock = 200 },
                     new { ProductSku = "2", TotalStock = 2000, AvailableStock = 1500, ReservedStock = 500 }
                 );

        builder.OwnsOne(product => product.ProductPrices).HasData(
             new { ProductSku = "1", CostPrice = (double)60, SellingPrice = (double)100, Discount = (double)15, IsDiscounted = true },
             new { ProductSku = "2", CostPrice = (double)140, SellingPrice = (double)200, Discount = (double)20, IsDiscounted = false }
         );

        builder.OwnsOne(product => product.TimeStamps).HasData(
             new { ProductSku = "1", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { ProductSku = "2", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
         );


    }
}
