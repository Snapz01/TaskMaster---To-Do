using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class Todo
    {
        // Parameterless constructor required by EF Core
        public Todo()
        {
            Description = string.Empty;
        }

        public Todo(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public Todo(int id, string description, bool done, Person? assignee = null)
        {
            Id = id;
            Description = description;
            Done = done;
            Assignee = assignee;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }

        public bool Done { get; set; }

        public Person? Assignee { get; set; }
    }
}
