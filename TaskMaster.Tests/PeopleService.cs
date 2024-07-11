using Xunit;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Tests
{
    public class PeopleServiceTests
    {
        [Fact]
        public void Size_ReturnZero()
        {
            var service = new PeopleService();

            int size = service.Size();

            Assert.Equal(0, size);
        }

        [Fact]
        public void Peron_equalSamePerson()
        {
            var service = new PeopleService();
            var person = service.CreatePerson("Timmy Larsson", 30);

            var foundPerson = service.FindById(person.Id);

            Assert.Equal(person, foundPerson);
        }

        [Fact]
        public void Clear_ShouldRemoveAllPeople()
        {
            var service = new PeopleService();
            service.CreatePerson("John Doe", 30);

            service.Clear();
            var allPeople = service.FindAll();

            Assert.Empty(allPeople);
        }
    }
}
