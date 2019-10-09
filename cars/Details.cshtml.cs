using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDcars.Data;

namespace CRUDcars.Pages.cars
{
    public class DetailsModel : PageModel
    {
        private readonly CRUDcars.Data.ApplicationDbContext _context;

        public DetailsModel(CRUDcars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
