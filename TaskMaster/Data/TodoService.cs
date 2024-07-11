using System;
using System.Linq;
using TaskMaster.Models;

namespace TaskMaster.Data
{
    public class TodoService
    {
        private static Todo[] todos = new Todo[0];

        public int Size()
        {
            return todos.Length;
        }

        public Todo[] FindAll()
        {
            return todos;
        }

        public Todo FindById(int todoId)
        {
            return todos.FirstOrDefault(t => t.Id == todoId);
        }

        public Todo CreateTodo(string description)
        {
            int todoId = TodoSequencer.NextTodoId();
            Todo newTodo = new Todo(todoId, description);

            Array.Resize(ref todos, todos.Length + 1);
            todos[todos.Length - 1] = newTodo;

            return newTodo;
        }

        public void Clear()
        {
            todos = new Todo[0];
        }
    }
}
