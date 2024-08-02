using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

namespace TaskMaster
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);

                // Seed data
                entity.HasData(
                    new Person(1, "John", "Doe"),
                    new Person(2, "Jane", "Smith")
                );
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);

                // Seed data using the parameterized constructor
                entity.HasData(
                    new Todo(1, "Sample Todo 1", false),
                    new Todo(2, "Sample Todo 2", true)
                );
            });
        }
    }
}
