using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Stops
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
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            //ViewData["CityID"] = new SelectList(_context.City, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Stop Stop { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stop.Add(Stop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
