using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActorsAndMovies.Controllers
{
    [ApiController]
    [Route("/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allMovies = await movieRepository.GetAllMoviesAsync();
            return new JsonResult(allMovies);
        }

        [HttpGet("{movieId}/details")]
        public async Task<IActionResult> Details(int movieId)
        {
            var movie = await movieRepository.GetMovieByIdAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(movie);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                await movieRepository.AddMovieAsync(movie);
                return Ok(movie);
            }
        }

        [HttpPut("{movieId}/update")]
        public async Task<IActionResult> Update(Movie movie)
        {
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                await movieRepository.UpdateMovieAsync(movie);
                return Ok(movie);
            }
        }

        [HttpDelete("{movieid}/delete")]
        public async Task<IActionResult> Delete(int movieid)
        {
            var movieToDelete = await movieRepository.GetMovieByIdAsync(movieid);
            if (movieToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await movieRepository.DeleteMovieAsync(movieid);
                return Ok(movieToDelete);
            }
        }

    }
}
