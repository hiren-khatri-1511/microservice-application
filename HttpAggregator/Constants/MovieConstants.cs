namespace HttpAggregator.Constants
{
    public static class MovieConstants
    {
        public const string BASE_URL= "http://host.docker.internal:4201";
        public const string GET_MOVIES_BY_GENRE_ENDPOINT = "/api/Movie/getMoviesByGenre/";
        public const string NULL_PARAM_MESSAGE = "Please provide genre name";
        public const string SUCCESS_MESSAGE = "Request has been successfully completed";
    }
}
