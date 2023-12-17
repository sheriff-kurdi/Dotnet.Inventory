using Kurdi.Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;


namespace Kurdi.Inventory.Infrastructure.Configurations.Entities
{
    internal class LanguagesConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(language => language.LanguageCode);

            builder.HasData(
                new Language
                {
                    LanguageName = "Arabic",
                    LanguageCode = "ar",
                    Activation = true,
                },
                new Language
                {
                    LanguageName = "English",
                    LanguageCode = "en",
                    Activation = true,
                }
            );

            builder.OwnsOne(language => language.TimeStamps);
            builder.OwnsOne(language => language.TimeStamps).Property(timeStamps => timeStamps.CreatedAt).HasColumnName("created_at");
            builder.OwnsOne(language => language.TimeStamps).Property(timeStamps => timeStamps.UpdatedAt).HasColumnName("updated_at");
            builder.OwnsOne(language => language.TimeStamps).Property(timeStamps => timeStamps.DeletedAt).HasColumnName("deleted_at");

            builder.OwnsOne(language => language.TimeStamps).HasData(
             new { LanguageCode = "ar", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null },
             new { LanguageCode = "en", CreatedAt = DateTime.UtcNow, UpdatedAt = (DateTime?)null, DeletedAt = (DateTime?)null });
        }
    }
}



