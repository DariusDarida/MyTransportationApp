using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Data;
using MyTransportationApp.Models;

namespace MyTransportationApp.Pages.Transporters
{
    public class IndexModel : PageModel
    {
        private readonly MyTransportationApp.Data.MyTransportationAppContext _context;

        public IndexModel(MyTransportationApp.Data.MyTransportationAppContext context)
        {
            _context = context;
        }

        public IList<Transporter> Transporter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transporter = await _context.Transporter
                .Include(t => t.Country).ToListAsync();
        }
    }
}
