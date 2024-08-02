using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
