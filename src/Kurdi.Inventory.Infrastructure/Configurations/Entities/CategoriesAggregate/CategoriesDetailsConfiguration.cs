using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;


namespace Kurdi.Inventory.Infrastructure.Configurations.Entities.CategoriesAggregate
{
    internal class CategoriesDetailsConfiguration : IEntityTypeConfiguration<CategoryDetails>
    {
        public void Configure(EntityTypeBuilder<CategoryDetails> builder)
        {
            builder.HasKey(details => new { details.LanguageCode, details.CategoryName });
            builder.Property(categoryDetails => categoryDetails.CategoryName).IsRequired();
            builder.Property(categoryDetails => categoryDetails.CategoryName).IsRequired();
            builder.Property(categoryDetails => categoryDetails.CategoryName).IsRequired();
            builder.Property(categoryDetails => categoryDetails.LanguageCode).IsRequired();

            builder.HasOne(categoryDetails => categoryDetails.Language).WithMany().HasForeignKey("LanguageCode");
            builder.HasOne(categoryDetails => categoryDetails.Category).WithMany().HasForeignKey("CategoryName");

            builder.OwnsOne(categoryDetails => categoryDetails.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
            builder.OwnsOne(categoryDetails => categoryDetails.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasColumnName("updated_at");
            builder.OwnsOne(categoryDetails => categoryDetails.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasColumnName("deleted_at");


            builder.HasData(
                        new CategoryDetails
                        {
                            CategoryName = "MEN",
                            TranslatedName = "Men",
                            Description = "Men Description",
                            LanguageCode = "en",
                        },
                        new CategoryDetails
                        {
                            CategoryName = "MEN",
                            TranslatedName = "رجالي",
                            Description = "الوصف رجالي",
                            LanguageCode = "ar",
                        },
                        new CategoryDetails
                        {
                            CategoryName = "WOMEN",
                            TranslatedName = "Men",
                            Description = "Women Description",
                            LanguageCode = "en",
                        },
                        new CategoryDetails
                        {
                            CategoryName = "WOMEN",
                            TranslatedName = "نسائي",
                            Description = "نسائي الوصف",
                            LanguageCode = "ar",
                        }
            );

            builder.OwnsOne(categoryDetails => categoryDetails.TimeStamps).HasData(
             new { CategoryDetailsLanguageCode = "ar", CategoryDetailsCategoryName = "MEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { CategoryDetailsLanguageCode = "en", CategoryDetailsCategoryName = "MEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { CategoryDetailsLanguageCode = "ar", CategoryDetailsCategoryName = "WOMEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { CategoryDetailsLanguageCode = "en", CategoryDetailsCategoryName = "WOMEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
            );

        }


    }
}
