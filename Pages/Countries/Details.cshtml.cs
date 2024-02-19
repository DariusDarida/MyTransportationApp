using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Countries
{
    public class DetailsModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public DetailsModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public Country Country { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Country.FirstOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            else
            {
                Country = country;
            }
            return Page();
        }
    }
}
