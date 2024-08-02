using TaskMaster.Models;

namespace TaskMaster.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; } = new List<Person>();
        public string SearchString { get; set; } = string.Empty;
    }
}