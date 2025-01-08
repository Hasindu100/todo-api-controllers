using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.DataAccess;
using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }
        public List<Todo> getAllTodos()
        {
            var todoList = _context.Todos.ToList();
            return todoList;
        }

        public Todo GetTodo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
