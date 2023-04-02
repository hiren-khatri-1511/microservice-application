namespace MovieMicroservice.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class MovieResponse
    {
        public List<Movie>? Movies { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
