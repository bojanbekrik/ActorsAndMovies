using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ActorsAndMovies.Models
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext context;

        public ActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return await context.Actors
                .Include(am => am.ActorMovies)
                .ThenInclude(m => m.Movie)
                .OrderBy(a=>a.ActorId)
                .ToListAsync();
        }

        public async Task<Actor?> GetActorByIdAsync(int id)
        {
            return await context.Actors
                .Include (am => am.ActorMovies)
                .ThenInclude (m => m.Movie)
                .FirstOrDefaultAsync(a => a.ActorId == id);
        }

        public async Task<int> AddActorAsync(Actor actor)
        {
            await context.Actors.AddAsync(actor);
            return await context.SaveChangesAsync();
        }

        
        public async Task UpdateActorAsync(Actor actor, IEnumerable<int> selectedMovieIds)
        {
            var existingIds = actor.ActorMovies.Select(sc => sc.MovieId).ToList();
            var toAdd = selectedMovieIds.Except(existingIds).ToList();
            var toRemove = existingIds.Except(selectedMovieIds).ToList();

            actor.ActorMovies.RemoveAll(sc => toRemove.Contains(sc.MovieId));

            foreach (var movieId in toAdd)
            {
                actor.ActorMovies.Add(new ActorMovie()
                {
                    MovieId = movieId
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteActorAsync(int id)
        {
            var actorToDelete = await context.Actors
                .Include(am => am.ActorMovies)
                .ThenInclude(m => m.Movie)
                .FirstOrDefaultAsync(a=>a.ActorId == id);

            if (actorToDelete == null)
            {
                throw new ArgumentException("Actor to delete can not be found");
            }
            else
            {
                context.Actors.Remove(actorToDelete);
                return await context.SaveChangesAsync();
            }
        }
        
    }
}
