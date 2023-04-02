using System.Net;

namespace HttpAggregator.Movie.Service
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class MovieResponse
    {
        public List<MovieModel>? Movies { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
