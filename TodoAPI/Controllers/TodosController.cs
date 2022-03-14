using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Model;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private TodoContext _todoContext { get; set; }
        public TodosController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        //GET/api/Todo
        [HttpGet]
        public IActionResult GetAllImenik()
        {
            var imenikDto = _todoContext.Todos.ToList();
            return Ok(imenikDto);
        }
        
        //GET/api/Todo/1
        [HttpGet("{id}")]
        public Todo GetTodo(int id)
        {
            var todo = _todoContext.Todos.SingleOrDefault(i => i.Id == id);

            if (todo == null)
                throw new Exception();

            return todo;
        }

        //PUT/api/Todo/5
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
  
        //POST/api/Todo
        [HttpPost]
        public Todo CreateTodo([FromBody] Todo todo)
        {
            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();

            return todo;
        }

        //DELETE/api/Todo/5
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
