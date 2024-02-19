using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTransportationApp.Models;

namespace MyTransportationApp.Data
{
    public class MyTransportationAppContext : DbContext
    {
        public MyTransportationAppContext (DbContextOptions<MyTransportationAppContext> options)
            : base(options)
        {
        }

        public DbSet<MyTransportationApp.Models.Country> Country { get; set; } = default!;
        public DbSet<MyTransportationApp.Models.City> City { get; set; } = default!;
        public DbSet<MyTransportationApp.Models.Transporter> Transporter { get; set; } = default!;
        public DbSet<MyTransportationApp.Models.Stop> Stop { get; set; } = default!;
        public DbSet<MyTransportationApp.Models.Train> Train { get; set; } = default!;
        public DbSet<MyTransportationApp.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
