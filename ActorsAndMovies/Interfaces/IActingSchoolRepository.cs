using ActorsAndMovies.Models;

namespace ActorsAndMovies.Interfaces
{
    public interface IActingSchoolRepository
    {
        Task<IEnumerable<ActingSchool>> GetAllActingSchoolsAsync();

        Task<ActingSchool> GetActingSchoolByIdAsync(int id);

        Task<int> AddActingSchoolAsync(ActingSchool actingSchool);

        Task<int> UpdateActingSchoolAsync(ActingSchool actingSchool);

        Task<int> DeleteActingSchoolAsync(int id);
    }
}
