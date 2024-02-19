using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Trains
{
    public class CreateModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public CreateModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TransporterID"] = new SelectList(_context.Set<Transporter>(), "ID", "TransporterName");
            // ViewData["TransporterID"] = new SelectList(_context.Transporter, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Train Train { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Train.Add(Train);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
