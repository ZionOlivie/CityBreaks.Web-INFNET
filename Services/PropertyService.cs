using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }
        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName)
        {
            var query = _context.Properties
                .Include(p => p.City)
                .Where(p => p.DeletedAt == null)
                .AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                query = query.Where(p => p.City != null && p.City.Name.Contains(cityName));
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                query = query.Where(p => p.Name.Contains(propertyName));
            }

            return await query.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prop = await _context.Properties.FindAsync(id);
            if (prop != null)
            {
                prop.DeletedAt = DateTime.Now; 
                await _context.SaveChangesAsync();
            }
        }
    }
}