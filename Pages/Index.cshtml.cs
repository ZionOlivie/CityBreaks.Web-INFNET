using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService)
        {
            _cityService = cityService;
        }
        public List<City> Cidades { get; set; } = new List<City>();
        public async Task OnGetAsync()
        {
            Cidades = await _cityService.GetAllAsync();
        }
    }
}