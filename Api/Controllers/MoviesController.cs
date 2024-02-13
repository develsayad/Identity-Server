using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class MoviesController : ControllerBase
    {

        private readonly MoviesApiContext _context;
        public MoviesController(MoviesApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Movies.ToList());
        }


        [HttpPost]
        public IActionResult Add(Movie movie)
        {

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie.MovieId);
        }




    }
}
