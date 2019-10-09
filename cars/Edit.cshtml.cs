using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDcars.Data;

namespace CRUDcars.Pages.cars
{
    public class EditModel : PageModel
    {
        private readonly CRUDcars.Data.ApplicationDbContext _context;

        public EditModel(CRUDcars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cars cars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cars = await _context.cars
                .Include(c => c.mans).FirstOrDefaultAsync(m => m.CID == id);

            if (cars == null)
            {
                return NotFound();
            }
           ViewData["MID"] = new SelectList(_context.Manufacturers, "MID", "MID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carsExists(cars.CID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool carsExists(int id)
        {
            return _context.cars.Any(e => e.CID == id);
        }
    }
}
