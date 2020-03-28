
using Microsoft.EntityFrameworkCore;

namespace Park.Models
{
    public class ParkContext : DbContext
    {
        public ParkContext(DbContextOptions<ParkContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal> ().HasData
            (
                new Animal { AnimalId = 1, Name = "Matilda", Species = "Woolly Mamoth", Age = 7, Gender = "Female"},
                new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10, Gender = "Female"},
                new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2, Gender = "Female"},
                new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4, Gender = "Male"},
                new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22, Gender = "Male"}
            );
        }
    }
}