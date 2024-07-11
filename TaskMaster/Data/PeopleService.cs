using TaskMaster.Models;

namespace TaskMaster.Data
{
    public class PeopleService
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        }

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
            return people.FirstOrDefault(p => p.Id == personId);
        }

        public Person CreatePerson(string name, int age)
        {
            int personId = PersonSequencer.NextPersonId();
            Person newPerson = new Person { Id = personId, Name = name, Age = age };

            Array.Resize(ref people, people.Length + 1);
            people[people.Length - 1] = newPerson;

            return newPerson;
        }

        public void Clear()
        {
            people = new Person[0];
        }
    }
}
