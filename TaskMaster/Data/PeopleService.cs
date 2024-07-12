using System.Linq;
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

        public Person CreatePerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person newPerson = new Person(personId, firstName, lastName);

            Array.Resize(ref people, people.Length + 1);
            people[people.Length - 1] = newPerson;

            return newPerson;
        }

        public void Clear()
        {
            people = new Person[0];
        }

        public void RemovePersonById(int personId)
        {
            int index = Array.FindIndex(people, p => p.Id == personId);
            if (index >= 0)
            {
                people = people.Where((val, idx) => idx != index).ToArray();
            }
        }
    }
}
