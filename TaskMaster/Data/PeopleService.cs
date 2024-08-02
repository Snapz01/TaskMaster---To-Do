using System.Linq;
using TaskMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskMaster.Data
{
    public class PeopleService
    {
        private readonly AppDbContext _context;

        public PeopleService(AppDbContext context)
        {
            _context = context;
        }

        public int Size()
        {
            return _context.Persons.Count();
        }

        public Person[] FindAll()
        {
            return _context.Persons.ToArray();
        }

        public Person? FindById(int personId)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == personId);
        }

        public Person CreatePerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person newPerson = new Person(personId, firstName, lastName);

            _context.Persons.Add(newPerson);
            _context.SaveChanges();

            return newPerson;
        }

        public void Clear()
        {
            foreach (var person in _context.Persons)
            {
                _context.Persons.Remove(person);
            }
            _context.SaveChanges();
        }

        public void RemovePersonById(int personId)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == personId);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
