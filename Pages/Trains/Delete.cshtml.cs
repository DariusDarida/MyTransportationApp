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
    public class DeleteModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public DeleteModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FindAsync(id);
            if (train != null)
            {
                Train = train;
                _context.Train.Remove(Train);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
