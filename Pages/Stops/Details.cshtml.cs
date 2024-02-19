using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Stops
{
    public class DetailsModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public DetailsModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public Stop Stop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = await _context.Stop.FirstOrDefaultAsync(m => m.ID == id);
            if (stop == null)
            {
                return NotFound();
            }
            else
            {
                Stop = stop;
            }
            return Page();
        }
    }
}
