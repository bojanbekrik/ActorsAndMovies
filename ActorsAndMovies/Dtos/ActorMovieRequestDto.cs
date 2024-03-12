namespace ActorsAndMovies.Dtos
{
    public class ActorMovieRequestDto
    {
        public int ActorId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Country { get; set; }

        public int[] MovieIds { get; set; }
    }
}