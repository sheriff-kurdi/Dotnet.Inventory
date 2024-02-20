using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;


namespace Kurdi.Inventory.Infrastructure.Configurations.Entities.ProductsAggregate
{
    internal class ProductsDetailsConfiguration : IEntityTypeConfiguration<ProductDetails>
    {

        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(details => new { details.LanguageCode, details.Sku });
            builder.Property(productDetails => productDetails.Name);
            builder.Property(productDetails => productDetails.Description);
            builder.Property(productDetails => productDetails.Sku);
            builder.Property(productDetails => productDetails.LanguageCode);

            builder.HasOne(productDetails => productDetails.Language).WithMany().HasForeignKey("LanguageCode");
            builder.HasOne(productDetails => productDetails.Product).WithMany().HasForeignKey("Sku");

            builder.OwnsOne(productDetails => productDetails.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
            builder.OwnsOne(productDetails => productDetails.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasColumnName("updated_at");
            builder.OwnsOne(productDetails => productDetails.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasColumnName("deleted_at");

            builder.HasData(
                new ProductDetails
                {
                    Sku = "1",
                    Name = "Shirt",
                    Description = "Shirt Description",
                    LanguageCode = "en",
                },
                new ProductDetails
                {
                    Sku = "1",
                    Name = "الاسم 1",
                    Description = "الوصف 1",
                    LanguageCode = "ar",
                }, new ProductDetails
                {
                    Sku = "2",
                    Name = "T-Shirt",
                    Description = "T-Shirt Description",
                    LanguageCode = "en",
                },
                new ProductDetails
                {
                    Sku = "2",
                    Name = "الاسم 2",
                    Description = "الوصف 2",
                    LanguageCode = "ar",
                }
            );

            builder.OwnsOne(productDetails => productDetails.TimeStamps).HasData(
             new { ProductDetailsSku = "1", ProductDetailsLanguageCode = "ar", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { ProductDetailsSku = "1", ProductDetailsLanguageCode = "en", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { ProductDetailsSku = "2", ProductDetailsLanguageCode = "ar", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { ProductDetailsSku = "2", ProductDetailsLanguageCode = "en", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
         );

        }
    }
}
