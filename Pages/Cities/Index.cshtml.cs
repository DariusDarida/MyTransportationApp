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
    public class IndexModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public IndexModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            City = await _context.City
                .Include(c => c.Country).ToListAsync();
        }
    }
}
