using ActorsAndMovies.Dtos;
using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActorsAndMovies.Controllers
{
    [ApiController]
    [Route("/actingSchool")]
    public class ActingSchoolController : ControllerBase
    {
        private readonly IActingSchoolRepository actingSchoolRepository;

        public ActingSchoolController(IActingSchoolRepository actingSchoolRepository)
        {
            this.actingSchoolRepository = actingSchoolRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allSchools = await actingSchoolRepository.GetAllActingSchoolsAsync();
            return new JsonResult(allSchools);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var school = await actingSchoolRepository.GetActingSchoolByIdAsync(id);
            return new JsonResult(school);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActingSchoolAddressDto asad)
        {
            var actSch = new ActingSchool()
            {
                Name = asad.Name,
                AddressId = asad.AddressId
            };

            await actingSchoolRepository.AddActingSchoolAsync(actSch);
            return Ok(actSch);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(ActingSchoolAddressDto asad, int id)
        {
            var schoolToUpdate = await actingSchoolRepository.GetActingSchoolByIdAsync(id);

            if (schoolToUpdate == null)
            {
                return NotFound();
            }
            
            schoolToUpdate.Name = asad.Name;
            schoolToUpdate.AddressId = asad.AddressId;

            await actingSchoolRepository.UpdateActingSchoolAsync(schoolToUpdate);
            return Ok(schoolToUpdate);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var schoolToDelete = await actingSchoolRepository.GetActingSchoolByIdAsync(id);
            if (schoolToDelete == null)
            {
                return NotFound();
            }

            await actingSchoolRepository.DeleteActingSchoolAsync(id);
            return Ok(schoolToDelete);
        }
    }
}
