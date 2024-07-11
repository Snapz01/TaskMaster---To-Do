using Xunit;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Tests
{
    public class TodoServiceTests
    {
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
    }
}
