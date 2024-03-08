using Microsoft.EntityFrameworkCore;

namespace ActorsAndMovies.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Actor>()
                .HasMany(am => am.ActorMovies)
                .WithOne(a => a.Actor)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Movie>()
                .HasMany(am => am.ActorMovies)
                .WithOne(m => m.Movie)
                .OnDelete(DeleteBehavior.SetNull);  

            modelBuilder.Entity<ActorMovie>()
                .HasIndex(am => am.Id)
                .IsUnique();

        }
    }
}
