using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieCollectionContext : DbContext
    {
        // constructor
        public MovieCollectionContext (DbContextOptions<MovieCollectionContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // seeded movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Television" },
                new Category { CategoryId = 7, CategoryName = "VHS" },
                new Category { CategoryId = 8, CategoryName = "Miscellaneous" }
            );


            mb.Entity<MovieResponse>().HasData(
                   new MovieResponse
                   {
                       MovieId = 1,
                       CategoryId = 1,
                       Title = "The Dark Knight",
                       Year = 2008,
                       Director = "Christopher Nolan",
                       Rating = "PG-13",
                       Edited = false,
                       Lent_To = null,
                       Notes = null
                   },
                   new MovieResponse
                   {
                       MovieId = 2,
                       CategoryId = 1,
                       Title = "The Lord of the Rings: The Return of the King",
                       Year = 2003,
                       Director = "Peter Jackson",
                       Rating = "PG-13",
                       Edited = false,
                       Lent_To = null,
                       Notes = null
                   },
                   new MovieResponse
                   {
                       MovieId = 3,
                       CategoryId = 1,
                       Title = "Jurassic Park 3",
                       Year = 2001,
                       Director = "Joe Johnston",
                       Rating = "PG-13",
                       Edited = false,
                       Lent_To = null,
                       Notes = null
                   }
            );
        }
    }
}
