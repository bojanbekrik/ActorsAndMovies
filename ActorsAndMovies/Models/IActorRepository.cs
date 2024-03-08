using System.Collections.Generic;

namespace ActorsAndMovies.Models
{
    public interface IActorRepository
    {
        public Task<IEnumerable<Actor>> GetAllActorsAsync();

        public Task<Actor?> GetActorByIdAsync(int id);

        public Task<int> AddActorAsync(Actor actor);

        //public Task UpdateActorAsync(Actor actor, IEnumerable<int> selectedMovieIds);
    }
}
