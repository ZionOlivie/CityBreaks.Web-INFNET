using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100).HasColumnName("Nome_Cidade");

            builder.HasData(
                new City { Id = 1, Name = "Rio de janeiro", CountryId = 1 },
                new City { Id = 2, Name = "Nova york", CountryId = 2 }
            );
        }
    }
}