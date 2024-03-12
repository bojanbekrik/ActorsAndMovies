using ActorsAndMovies.Models;

namespace ActorsAndMovies.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie> GetMovieByIdAsync(int movieId);

        Task<int> AddMovieAsync(Movie movie);

        Task<int> UpdateMovieAsync(Movie movie);

        Task<int> DeleteMovieAsync(int movieId);
    }
}
