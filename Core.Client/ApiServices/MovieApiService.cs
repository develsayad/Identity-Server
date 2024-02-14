using Core.Client.Models;

namespace Core.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {

            var movieList = new List<Movie>();
            movieList.Add(new Movie
            {
                Category = "cat-1",
                Description = "movie-1",
                Name = "movie-1",
                Owner = "owner-1",
                MovieId = 1
            });

            return await Task.FromResult(movieList);

        }

        public Task<Movie> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
