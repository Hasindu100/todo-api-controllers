using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services.Todos;

namespace TaskAPI.Controllers
{
    [Route("api/TodoController")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("{id?}")]
        public ActionResult<ICollection<Todo>> getTodos(int? id)
        {
            var myTodos = _todoService.getAllTodos();
            if (id is null)
            {
                return Ok(myTodos);
            }

            myTodos = myTodos.Where(x => x.Id == id).ToList();
            return Ok(myTodos);
        }
    }
}
