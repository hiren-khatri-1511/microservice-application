using MovieMicroservice.Configurations;
using MovieMicroservice.Models;

namespace MovieMicroservice.Services
{
    public class MovieService : IMovieService
    {
        private readonly DbConfig _context;

        public MovieService(DbConfig context)
        {
            this._context = context;
        }

        /// <summary>
        /// This method provides list of movies by based on genre category
        /// </summary>
        /// <param name="genre">passing genre name</param>
        /// <returns>return list of movie names</returns>
        public List<Movie> GetMoviesByGenre(string genre)
        {
            try
            {
                var movieList = _context.Movie.Where(movie => (movie.Genre != null)
                && (movie.Genre.ToLower()) == genre.ToLower()).ToList();
                
                return movieList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
