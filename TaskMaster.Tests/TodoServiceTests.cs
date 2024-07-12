using Xunit;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Tests
{
    public class TodoServiceTests
    {
        public TodoServiceTests()
        {
            // Ensure the service is in a clean state before each test
            var service = new TodoService();
            service.Clear();
            TodoSequencer.Reset();
        }
        [Fact]
        public void Size_ReturnZero()
        {
            var service = new TodoService();

            int size = service.Size();

            Assert.Equal(0, size);
        }


        [Fact]
        public void Id_ShouldReturnTodo()
        {
            var service = new TodoService();
            var todo = service.CreateTodo("Test todo");

            var foundTodo = service.FindById(todo.Id);

            Assert.Equal(todo, foundTodo);
        }

        [Fact]
        public void Clear_ShouldRemoveAllTodos()
        {
            var service = new TodoService();
            service.CreateTodo("Test todo");

            service.Clear();
            var allTodos = service.FindAll();

            Assert.Empty(allTodos);
        }

        [Fact]
        public void FindByAssignee_MatchID()
        {
            var service = new TodoService();
            var person = new Person(1, "John", "Doe");
            var todo1 = service.CreateTodo("Test todo 1");
            var todo2 = service.CreateTodo("Test todo 2");
            todo2.Assignee = person;

            var assignedTodos = service.FindByAssignee(person.Id);

            Assert.Single(assignedTodos);
            Assert.Equal(todo2, assignedTodos[0]);
        }

        [Fact]
        public void FindByAssignee_MatchPerson()
        {
            var service = new TodoService();
            var person = new Person(1, "Timmy", "Larsson");
            var todo1 = service.CreateTodo("Test todo 1");
            var todo2 = service.CreateTodo("Test todo 2");
            todo2.Assignee = person;

            var assignedTodos = service.FindByAssignee(person);

            Assert.Single(assignedTodos);
            Assert.Equal(todo2, assignedTodos[0]);
        }

        [Fact]
        public void FindUnassignedTodoItems()
        {
            var service = new TodoService();
            var person = new Person(1, "Timmy", "Larsson");
            var todo1 = service.CreateTodo("Test todo 1");
            var todo2 = service.CreateTodo("Test todo 2");
            todo2.Assignee = person;

            var unassignedTodos = service.FindUnassignedTodoItems();

            Assert.Single(unassignedTodos);
            Assert.Equal(todo1, unassignedTodos[0]);
        }

        [Fact]
        public void RemoveTodoById()
        {
            var service = new TodoService();
            var todo1 = service.CreateTodo("Test todo 1");
            var todo2 = service.CreateTodo("Test todo 2");

            service.RemoveTodoById(todo1.Id);
            var allTodos = service.FindAll();

            Assert.Single(allTodos);
            Assert.Equal(todo2, allTodos[0]);
        }
    }
}
