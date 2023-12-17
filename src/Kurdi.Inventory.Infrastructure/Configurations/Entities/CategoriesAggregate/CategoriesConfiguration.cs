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
            builder.HasKey(Category => Category.Name);
            builder.HasMany(Category => Category.CategoryDetails).WithOne().HasForeignKey("Name"); ;
            builder.Property(Category => Category.Name).IsRequired();
            builder.Property(Category => Category.Activation).IsRequired();

            builder.HasOne(Category => Category.Parent).WithMany().HasForeignKey("ParentName");
            builder.Property(Category => Category.HasParent).IsRequired();
            builder.Property(Category => Category.ParentName);

            builder.OwnsOne(Category => Category.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
            builder.OwnsOne(Category => Category.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasColumnName("updated_at");
            builder.OwnsOne(Category => Category.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasColumnName("deleted_at");



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

            builder.OwnsOne(Category => Category.TimeStamps).HasData(
             new { CategoryName = "MEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { CategoryName = "WOMEN", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null }
         );
        }
    }
}
