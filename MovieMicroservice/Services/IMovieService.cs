using MovieMicroservice.Models;

namespace MovieMicroservice.Services
{
    public interface IMovieService
    {
       public List<Movie> GetMoviesByGenre(string genre);
    }
}
