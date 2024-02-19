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

namespace MyTransportationApp.Pages.Stops
{
    public class EditModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public EditModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stop Stop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop =  await _context.Stop.FirstOrDefaultAsync(m => m.ID == id);
            if (stop == null)
            {
                return NotFound();
            }
            Stop = stop;
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "ID", "CityName");
            //ViewData["CityID"] = new SelectList(_context.City, "ID", "ID");
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

            _context.Attach(Stop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopExists(Stop.ID))
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

        private bool StopExists(int id)
        {
            return _context.Stop.Any(e => e.ID == id);
        }
    }
}
