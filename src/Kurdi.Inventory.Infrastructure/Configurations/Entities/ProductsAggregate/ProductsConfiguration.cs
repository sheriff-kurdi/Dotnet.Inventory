﻿using System;
using System.Reflection.Emit;
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
        builder.Property(Product => Product.CategoryName).IsRequired();

        builder.HasMany(Product => Product.ProductDetails).WithOne().HasForeignKey("Sku");

        builder.Property(Product => Product.SupplierIdentity).IsRequired();
        builder.Property(Product => Product.Activation).IsRequired();


        builder.OwnsOne(produt => produt.ProductPrices);
        builder.OwnsOne(produt => produt.ProductPrices).Property(price => price.CostPrice).IsRequired().HasColumnName("cost_price");
        builder.OwnsOne(produt => produt.ProductPrices).Property(price => price.SellingPrice).IsRequired().HasColumnName("selling_price");
        builder.OwnsOne(produt => produt.ProductPrices).Property(price => price.IsDiscounted).IsRequired().HasColumnName("is_discounted");
        builder.OwnsOne(produt => produt.ProductPrices).Property(price => price.Discount).IsRequired().HasColumnName("discount");

        builder.OwnsOne(produt => produt.ProductQuantity);
        builder.OwnsOne(produt => produt.ProductQuantity).Property(price => price.TotalStock).IsRequired().HasColumnName("total_stock");
        builder.OwnsOne(produt => produt.ProductQuantity).Property(price => price.AvailableStock).IsRequired().HasColumnName("available_stock");
        builder.OwnsOne(produt => produt.ProductQuantity).Property(price => price.ReservedStock).IsRequired().HasColumnName("reserved_stock");

        builder.OwnsOne(produt => produt.TimeStamps);
        builder.OwnsOne(produt => produt.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
        builder.OwnsOne(produt => produt.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasDefaultValue(null).HasColumnName("updated_at");
        builder.OwnsOne(produt => produt.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasDefaultValue(null).HasColumnName("deleted_at");



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

        builder.OwnsOne(produt => produt.ProductQuantity).HasData(
                     new { ProductSku = "1", TotalStock = 1000, AvailableStock = 800, ReservedStock = 200 },
                     new { ProductSku = "2", TotalStock = 2000, AvailableStock = 1500, ReservedStock = 500 }
                 );

        builder.OwnsOne(produt => produt.ProductPrices).HasData(
             new { ProductSku = "1", CostPrice = (double)60, SellingPrice = (double)100, Discount = (double)15, IsDiscounted = true },
             new { ProductSku = "2", CostPrice = (double)140, SellingPrice = (double)200, Discount = (double)20, IsDiscounted = false }
         );

        builder.OwnsOne(produt => produt.TimeStamps).HasData(
             new { ProductSku = "1", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { ProductSku = "2", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
         );


    }
}
