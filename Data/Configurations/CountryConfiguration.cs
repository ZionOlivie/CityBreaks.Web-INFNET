using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName).HasMaxLength(100).HasColumnName("Nome_Pais");
            builder.Property(c => c.CountryCode).HasMaxLength(3);

            builder.HasData(
                new Country { Id = 1, CountryCode = "BRA", CountryName = "Brasil" },
                new Country { Id = 2, CountryCode = "USA", CountryName = "Estados Unidos" }
            );
        }
    }
}