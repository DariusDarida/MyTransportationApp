using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public IndexModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Country = await _context.Country.ToListAsync();
        }
    }
}
