using HttpAggregator.Movie.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(Name = "getMoviesByGenre/{genre}")]
        public async Task<ActionResult<MovieResponse>> Get(string genre) 
        {
            var movies = await _movieService.GetMoviesByGenre(genre);
            
            return movies != null ? movies : BadRequest();
        }
    }
}
