using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Cities
{
    public class EditModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public EditModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  await _context.City.FirstOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }
            City = city;
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "CountryName");
            //ViewData["CountryID"] = new SelectList(_context.Country, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(City).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(City.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.ID == id);
        }
    }
}
