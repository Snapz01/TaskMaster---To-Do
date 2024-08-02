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

        public Todo? FindById(int todoId)
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

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return todos.Where(t => t.Done == doneStatus).ToArray();
        }

        public Todo[] FindByAssignee(int personId)
        {
            return todos.Where(t => t.Assignee != null && t.Assignee.Id == personId).ToArray();
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            return todos.Where(t => t.Assignee == assignee).ToArray();
        }

        public Todo[] FindUnassignedTodoItems()
        {
            return todos.Where(t => t.Assignee == null).ToArray();
        }

        public void RemoveTodoById(int todoId)
        {
            int index = Array.FindIndex(todos, t => t.Id == todoId);
            if (index >= 0)
            {
                todos = todos.Where((val, idx) => idx != index).ToArray();
            }
        }
    }
}
