using System.Collections.Generic;
using ActorsAndMovies.Models;

namespace ActorsAndMovies.Interfaces
{
    public interface IActorRepository
    {
        public Task<IEnumerable<Actor>> GetAllActorsAsync();

        public Task<Actor?> GetActorByIdAsync(int id);

        public Task<int> AddActorAsync(Actor actor);

        Task UpdateActorAsync(Actor actor, IEnumerable<int> selectedMovieIds);

        public Task<int> DeleteActorAsync(int id);
    }
}
