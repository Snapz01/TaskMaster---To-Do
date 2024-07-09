namespace TaskMaster.Models
{
    public class Person
    {
        public Person()
        {
        }

        // Private fields
        private readonly int id; //read only
        private string firstName;
        private string lastName;

        // Constructor
        public Person(int id)
        {
            this.id = id;
            this.firstName = string.Empty;
            this.lastName = string.Empty;
        }

        public Person(int id, string firstName, string lastName)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        //Public values / no nulls or empties
        public int Id => id;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty");
                }
                lastName = value;
            }
        }
    }
}
