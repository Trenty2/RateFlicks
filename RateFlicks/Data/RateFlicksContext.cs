using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RateFlicks.Models;

namespace RateFlicks.Data
{
    public class RateFlicksContext : DbContext
    {
        public RateFlicksContext (DbContextOptions<RateFlicksContext> options)
            : base(options)
        {
        }

        public DbSet<RateFlicks.Models.Movie> Movie { get; set; }
    }
}
