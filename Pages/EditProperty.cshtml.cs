using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;
        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        public Property Propriedade { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Propriedade = await _context.Properties.FindAsync(id);

            if (Propriedade == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propToUpdate = await _context.Properties.FindAsync(id);

            if (propToUpdate == null) return NotFound();
            if (await TryUpdateModelAsync<Property>(
                propToUpdate,
                "Propriedade", // Prefixo do formulário
                p => p.Name, p => p.PricePerNight))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
