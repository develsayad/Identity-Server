using Core.Client.ApiServices;
using Core.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;

namespace Core.Client.Controllers
{

    [Authorize]
    public class MoviesController : Controller
    {

        private readonly IMovieApiService _movieApiService;



        public MoviesController(IMovieApiService movieApiService)
        {
            //_context = context;
            _movieApiService = movieApiService;
        }


        public async Task<IActionResult> Index()
        {
            //return _context.Movie != null ?
            //            View(await _context.Movie.ToListAsync()) :

            //            Problem("Entity set 'CoreClientContext.Movie'  is null.");

            LogTokenAndClaims();
            return View(await _movieApiService.GetAllMovies());
        }


        public async Task LogTokenAndClaims()
        {

            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Debug.WriteLine($"Identity Token:{identityToken}");
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type:{claim.Type} - Claim value:{claim.Value}");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Movie == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movie
            //    .FirstOrDefaultAsync(m => m.MovieId == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            return View(await _movieApiService.GetMovie(id.Value));
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Name,Description,Category,Owner")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(movie);
                //await _context.SaveChangesAsync();
                await _movieApiService.CreateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var movie = _movieApiService.GetMovie(id.Value);
            if (id == null || movie == null)
            {
                return NotFound();
            }


            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Name,Description,Category,Owner")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(movie);
                    //await _context.SaveChangesAsync();
                    await _movieApiService.UpdateMovie(movie);
                }
                catch (Exception ex)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var movie = await _movieApiService.GetMovie(id.Value);
            if (id == null || movie == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movie
            //    .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieApiService.GetMovie(id);
            if (movie == null)
            {
                return Problem("Entity set 'CoreClientContext.Movie'  is null.");
            }

            //_context.Movie.Remove(movie);
            await _movieApiService.DeleteMovie(movie);


            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            //return (_context.Movie?.Any(e => e.MovieId == id)).GetValueOrDefault();
            //var movie = ;
            return (_movieApiService.GetMovie(id).Result == null ? false : true);




        }
    }
}
