using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RateFlicks.Data;
using RateFlicks.Models;

namespace RateFlicks.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RateFlicks.Data.RateFlicksContext _context;

        public IndexModel(RateFlicks.Data.RateFlicksContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
