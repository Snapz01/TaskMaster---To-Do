using Xunit;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Tests
{
    public class PeopleServiceTests
    {
        public PeopleServiceTests()
        {
            // clean state..
            var service = new PeopleService();
            service.Clear();
            PersonSequencer.Reset();
        }

        [Fact]
        public void Size_ReturnsZero_ForNewService()
        {
            var service = new PeopleService();

            int size = service.Size();

            Assert.Equal(0, size);
        }

        [Fact]
        public void CreatePerson_AddsNewPersonToArray()
        {
            var service = new PeopleService();
            var person = service.CreatePerson("Bob", "Bobsson");

            var allPeople = service.FindAll();

            Assert.Single(allPeople);
            Assert.Equal(person, allPeople[0]);
        }

        [Fact]
        public void FindById_ReturnsCorrectPerson()
        {
            var service = new PeopleService();
            var person = service.CreatePerson("Timmy", "Larsson");

            var foundPerson = service.FindById(person.Id);

            Assert.Equal(person, foundPerson);
        }

        [Fact]
        public void Clear_RemovesAllPeople()
        {
            var service = new PeopleService();
            service.CreatePerson("John", "Doe");

            service.Clear();
            var allPeople = service.FindAll();

            Assert.Empty(allPeople);
        }

        [Fact]
        public void RemovePersonById_RemovesCorrectPerson()
        {
            var service = new PeopleService();
            var person1 = service.CreatePerson("Timmy", "Larsson");
            var person2 = service.CreatePerson("Timmy", "Larsson");

            service.RemovePersonById(person1.Id);
            var allPeople = service.FindAll();

            Assert.Single(allPeople);
            Assert.Equal(person2, allPeople[0]);
        }
    }
}
