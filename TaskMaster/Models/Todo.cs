namespace TaskMaster.Models
{
    public class Todo
    {
        // Private fields
        private readonly int id; //read only
        private string description;
        private bool done;
        private Person assignee;

        public Todo(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        // Constructor
        public Todo(int id, string description, bool done, Person assignee)
        {
            this.id = id;
            this.description = description;
            this.done = done;
            this.assignee = assignee;
        }

        //Public values
        public int Id
        {
            get { return id; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        public Person Assignee
        {
            get { return assignee; }
            set { assignee = value; }
        }
    }
}