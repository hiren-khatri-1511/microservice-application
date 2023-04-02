using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Models;
using MovieMicroservice.Services;

namespace MovieMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("getMoviesByGenre/{genre}")]
        public ActionResult<List<Movie>> GetMoviesByGenre(string genre)
        {
            var movies = _movieService.GetMoviesByGenre(genre);

            return movies != null ? movies : BadRequest();
        }
    }
}
