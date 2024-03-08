namespace ActorsAndMovies.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public List<ActorMovie> ActorMovies { get; set;  } = [];
    }
}