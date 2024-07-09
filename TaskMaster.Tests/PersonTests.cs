using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Models;
using Xunit;

namespace TaskMaster.Tests
{
    public class PersonTests
    {
        [Fact]
        public void constructTests()
        {
            // Arrange
            int expectedId = 1;
            string expectedFirstName = "Timmy";
            string expectedLastName = "Larsson";

            // Act
            var person = new Person(expectedId, expectedFirstName, expectedLastName);

            // Assert
            Assert.Equal(expectedId, person.Id);
            Assert.Equal(expectedFirstName, person.FirstName);
            Assert.Equal(expectedLastName, person.LastName);
        }
        [Fact]
        public void firstNameTestNull()
        {
            // Arrange
            var person = new Person(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.FirstName = null);
            Assert.Throws<ArgumentException>(() => person.FirstName = "");
        }

        [Fact]
        public void lastNameTestNull()
        {
            // Arrange
            var person = new Person(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.LastName = null);
            Assert.Throws<ArgumentException>(() => person.LastName = "");
        }

    }
}