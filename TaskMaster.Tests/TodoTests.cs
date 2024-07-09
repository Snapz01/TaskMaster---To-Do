using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TaskMaster.Models;

namespace TaskMaster.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Constructor()
        {
            // Arrange
            int id = 1;
            string description = "Test description";

            // Act
            var todo = new Todo(id, description);

            // Assert
            Assert.Equal(id, todo.Id);
            Assert.Equal(description, todo.Description);
            Assert.False(todo.Done);
            Assert.Null(todo.Assignee);
        }

        [Fact]
        public void Description_GetSet()
        {
            // Arrange
            var todo = new Todo(1, "Initial description");
            string newDescription = "Updated description";

            // Act
            todo.Description = newDescription;

            // Assert
            Assert.Equal(newDescription, todo.Description);
        }

        [Fact]
        public void Done_GetSet()
        {
            // Arrange
            var todo = new Todo(1, "Test description");

            // Act
            todo.Done = true;

            // Assert
            Assert.True(todo.Done);
        }

        [Fact]
        public void Assignee_GetSet()
        {
            // Arrange
            var todo = new Todo(1, "Test description");
            var person = new Person { FirstName = "Timmy", LastName = "Larsson" };

            // Act
            todo.Assignee = person;

            // Assert
            Assert.Equal(person, todo.Assignee);
        }
    }
}
