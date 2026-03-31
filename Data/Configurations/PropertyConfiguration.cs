using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).HasColumnName("Nome_Propriedade");
            builder.Property(p => p.PricePerNight).HasColumnType("decimal(18,2)");

            builder.HasData(
                new Property { Id = 1, Name = "Copacabana palace", PricePerNight = 1500.00m, CityId = 1 },
                new Property { Id = 2, Name = "Pousada ipanema", PricePerNight = 450.00m, CityId = 1 },
                new Property { Id = 3, Name = "Manhattan hotel", PricePerNight = 2500.00m, CityId = 2 }
            );
        }
    }
}