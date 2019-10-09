using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDcars.Data;

namespace CRUDcars.Pages.cars
{
    public class CreateModel : PageModel
    {
        private readonly CRUDcars.Data.ApplicationDbContext _context;

        public CreateModel(CRUDcars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MID"] = new SelectList(_context.Manufacturers, "MID", "MID");
            return Page();
        }

        [BindProperty]
        public cars cars { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cars.Add(cars);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}