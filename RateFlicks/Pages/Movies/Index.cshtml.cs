﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Ratings { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieRating { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                orderby m.Genre
                select m.Genre;
            // Use LINQ to get list of Ratings.
            IQueryable<string> ratingQuery = from m in _context.Movie
                orderby m.Rating
                select m.Rating;

            var movies = from m in _context.Movie
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            if (!string.IsNullOrEmpty(MovieRating))
            {
                movies = movies.Where(x => x.Rating == MovieRating);
            }


            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Ratings = new SelectList(await ratingQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
