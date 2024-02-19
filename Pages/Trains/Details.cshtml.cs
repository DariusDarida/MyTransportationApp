using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Trains
{
    public class DetailsModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public DetailsModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public Train Train { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FirstOrDefaultAsync(m => m.ID == id);
            if (train == null)
            {
                return NotFound();
            }
            else
            {
                Train = train;
            }
            return Page();
        }
    }
}
