using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace ActorsAndMovies.Repositories
{
    public class ActingSchoolRepository : IActingSchoolRepository
    {
        private readonly ApplicationDbContext context;

        public ActingSchoolRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ActingSchool>> GetAllActingSchoolsAsync()
        {
            return await context.ActingSchools.OrderBy(asch => asch.Id).ToListAsync();
        }

        public async Task<ActingSchool> GetActingSchoolByIdAsync(int id)
        {
            return await context.ActingSchools.FirstOrDefaultAsync(asch => asch.Id == id);
        }

        public async Task<int> AddActingSchoolAsync(ActingSchool actingSchool)
        {
            context.ActingSchools.Add(actingSchool);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateActingSchoolAsync(ActingSchool actingSchool)
        {
            context.ActingSchools.Update(actingSchool);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteActingSchoolAsync(int id)
        {
            var schoolToDelete = await context.ActingSchools.FirstOrDefaultAsync(asch => asch.Id == id);

            if (schoolToDelete == null) 
            {
                throw new ArgumentException("School cant be found");
            }

            context.ActingSchools.Remove(schoolToDelete);
            return await context.SaveChangesAsync();
        }
    }
}
