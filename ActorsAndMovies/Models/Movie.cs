namespace ActorsAndMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public List<ActorMovie> ActorMovies { get; } = [];
    }
}
