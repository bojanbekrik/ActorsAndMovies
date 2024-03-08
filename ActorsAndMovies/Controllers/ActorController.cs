using ActorsAndMovies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ActorsAndMovies.Controllers
{
    [ApiController]
    [Route("/actors")]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository actorRepository;
        private readonly ApplicationDbContext context;

        public ActorController(IActorRepository actorRepository, ApplicationDbContext context)
        {
            this.actorRepository = actorRepository;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allActors = await actorRepository.GetAllActorsAsync();
            //return new JsonResult(allActors);
            return Ok(allActors);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await actorRepository.GetActorByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(actor);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorMovieRequestDto amrd)
        {
            Actor actor = new Actor()
            {
                Name = amrd.Name,
                Surname = amrd.Surname,
                Country = amrd.Country,
            };

            foreach(var movie in amrd.MovieIds)
            {
                actor.ActorMovies.Add(new ActorMovie()
                {
                    Actor = actor,
                    MovieId = movie
                });
            }
            await actorRepository.AddActorAsync(actor);
            return Ok(actor);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(int id, ActorMovieRequestDto amrd)
        {
            var actor = await actorRepository.GetActorByIdAsync(id);

            actor.Name = amrd.Name;
            actor.Surname = amrd.Surname;
            actor.Country = amrd.Country;

            var existingIds = actor.ActorMovies.Select(am => am.Id).ToList();

            var selectedIds = amrd.MovieIds.ToList();

            var toAdd = selectedIds.Except(existingIds).ToList();

            var toRemove = existingIds.Except(selectedIds).ToList();

            actor.ActorMovies = actor.ActorMovies.Where(x => !toRemove.Contains(x.ActorId)).ToList();

            foreach(var item in toAdd)
            {
                actor.ActorMovies.Add(new ActorMovie()
                {
                    ActorId = item
                });
            }

            context.Actors.Update(actor);
            await context.SaveChangesAsync();
            return Ok(actor);   
        }
    }
}
