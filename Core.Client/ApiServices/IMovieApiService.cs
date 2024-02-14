using Core.Client.Models;

namespace Core.Client.ApiServices
{
    public interface IMovieApiService
    {

        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovie(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(Movie movie);

    }
}
