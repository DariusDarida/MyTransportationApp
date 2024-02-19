using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public DetailsModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                City = city;
            }
            return Page();
        }
    }
}
