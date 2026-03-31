using CityBreaks.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class DeletePropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;
        public DeletePropertyModel(CityBreaksContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var prop = await _context.Properties.FindAsync(id);

            if (prop != null)
            {
                prop.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}