using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class MoviesApiContext : DbContext
    {

        public MoviesApiContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Movie> Movies { get; set; }


    }
}
