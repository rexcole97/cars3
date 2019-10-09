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
    public class IndexModel : PageModel
    {
        private readonly CRUDcars.Data.ApplicationDbContext _context;

        public IndexModel(CRUDcars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cars> cars { get;set; }

        public async Task OnGetAsync()
        {
            cars = await _context.cars
                .Include(c => c.mans).ToListAsync();
        }
    }
}
