using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class Person
    {
        // Parameterless constructor required by EF Core
        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
    }
}
