namespace ActorsAndMovies.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public ActingSchool? ActingSchool { get; set; }
    }
}
