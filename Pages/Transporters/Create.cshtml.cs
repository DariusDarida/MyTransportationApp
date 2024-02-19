using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Transporters
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
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "CountryName");
            // ViewData["CountryID"] = new SelectList(_context.Country, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Transporter Transporter { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transporter.Add(Transporter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
