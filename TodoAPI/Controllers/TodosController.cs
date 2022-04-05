using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodosController : Controller
    {
        private TodoContext _todoContext { get; set; }
        public TodosController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        //GET/Todo
        [HttpGet]
        public IActionResult GetAllTodo()
        {
            var todos = _todoContext.Todos.ToList();
            return Ok(todos);
        }

        [Authorize]
        //GET/Todo/1
        [HttpGet("{id}")]
        public Todo GetTodo(int id)
        {
            var todo = _todoContext.Todos.SingleOrDefault(i => i.Id == id);

            if (todo == null)
                throw new Exception();

            return todo;
        }

        [Authorize]
        //PUT/Todo/5
        [HttpPut("{id}")]
        public void UpdateTodo(int id, [FromBody] Todo todo)
        {
            if (id != todo.Id)
                throw new Exception();

            var contactExist = _todoContext.Todos.SingleOrDefault(i => i.Id == id);

            if (contactExist == null)
                throw new Exception();

            _todoContext.SaveChanges();
        }
        
        [Authorize]
        //CREATE/Todo
        [HttpPost]
        public Todo CreateTodo([FromBody] Todo todo)
        {
            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();

            return todo;
        }

        [Authorize]
        //DELETE/Todo/5
        [HttpDelete("{id}")]
        public void DeleteTodo(int id)
        {
            var todo = _todoContext.Todos.SingleOrDefault(i => i.Id == id);

            if (todo == null)
                throw new Exception();

            _todoContext.Todos.Remove(todo);
            _todoContext.SaveChanges();
        }
    }
}
