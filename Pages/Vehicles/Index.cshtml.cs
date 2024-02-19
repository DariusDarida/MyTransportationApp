using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public IndexModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicle
                .Include(v => v.Transporter).ToListAsync();
        }
    }
}
