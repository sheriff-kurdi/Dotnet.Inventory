using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;


namespace Kurdi.Inventory.Infrastructure.Configurations.Entities.CategoriesAggregate
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Name);
            builder.HasMany(category => category.CategoryDetails).WithOne().HasForeignKey("Name");
            builder.Property(category => category.Name).IsRequired();
            builder.Property(category => category.Activation).IsRequired();

            builder.HasOne(category => category.Parent).WithMany().HasForeignKey("ParentName");
            builder.Property(category => category.HasParent).IsRequired();
            builder.Property(category => category.ParentName);

            builder.OwnsOne(category => category.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
            builder.OwnsOne(category => category.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasColumnName("updated_at");
            builder.OwnsOne(category => category.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasColumnName("deleted_at");



            builder.HasData(
                new Category
                {
                    Name = "MEN",
                    HasParent = false,
                    Activation = true,
                    ParentName = null,
                },
                new Category
                {
                    Name = "WOMEN",
                    HasParent = false,
                    Activation = true,
                    ParentName = null,
                });

            builder.OwnsOne(category => category.TimeStamps).HasData(
             new { CategoryName = "MEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { CategoryName = "WOMEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
         );
        }
    }
}
