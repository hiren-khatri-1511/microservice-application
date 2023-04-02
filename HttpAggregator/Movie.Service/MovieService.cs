using HttpAggregator.Constants;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HttpAggregator.Movie.Service
{
    public class MovieService
    {
        /// <summary>
        /// This method connect with movie ms using docker container base uri, 
        /// also provides http request/ resposne info
        /// </summary>
        /// <param name="genre">passing genre name</param>
        /// <returns>returns list of movies based on genre category</returns>
        public async Task<MovieResponse> GetMoviesByGenre(string genre)
        {
            MovieResponse movies = new MovieResponse();

            if (genre == null)
            {
                movies.StatusCode = System.Net.HttpStatusCode.NoContent;
                movies.Message = MovieConstants.NULL_PARAM_MESSAGE;

                return movies;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MovieConstants.BASE_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(MovieConstants.GET_MOVIES_BY_GENRE_ENDPOINT + genre);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();

                        movies = new MovieResponse();
                        movies.StatusCode = response.StatusCode;
                        movies.Message = MovieConstants.SUCCESS_MESSAGE;
                        movies.Movies = JsonConvert.DeserializeObject<List<MovieModel>>(responseString);
                    }
                }
            }

            catch (HttpRequestException ex)
            {
                movies.StatusCode = System.Net.HttpStatusCode.BadRequest;
                movies.Message = ex.Message;
            }
            catch (JsonSerializationException ex)
            {
                movies.StatusCode = System.Net.HttpStatusCode.UnsupportedMediaType;
                movies.Message = ex.Message;
            }
            catch (TimeoutException ex)
            {
                movies.StatusCode = System.Net.HttpStatusCode.RequestTimeout;
                movies.Message = ex.Message;
            }
            catch (Exception ex)
            {
                movies.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                movies.Message = ex.Message;
            }

            return movies;
        }
    }
}

