using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public CreatePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property NovaPropriedade { get; set; } = new Property();
        public SelectList? CidadesList { get; set; }
        public async Task OnGetAsync()
        {
            var cidades = await _context.Cities.ToListAsync();
            CidadesList = new SelectList(cidades, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Properties.AddAsync(NovaPropriedade);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}