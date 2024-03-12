using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace ActorsAndMovies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;

        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await context.Movies.OrderBy(m => m.MovieId).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Can not find movie with that id");
            }

            return movie;
        }

        public async Task<int> AddMovieAsync(Movie movie)
        {
            context.Movies.Add(movie);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateMovieAsync(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentException("Movie to update was not found");
            }

            context.Movies.Update(movie);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteMovieAsync(int movieId)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.MovieId == movieId);
            if (movie == null)
            {
                throw new ArgumentException("Movie like that was not found");
            }

            context.Movies.Remove(movie);
            return await context.SaveChangesAsync();
        }

    }
}
