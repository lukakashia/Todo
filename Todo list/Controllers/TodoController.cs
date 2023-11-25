using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Todo_list.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class TodoController : ControllerBase
    {
        
        private readonly ApplicationDbContext _dbContext;

        public TodoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Read all todos")]
        public async Task<IActionResult> ReadTodo()
        {
            var todos = await _dbContext.Todos.ToListAsync();

            return Ok(todos);
        }


        [HttpGet("Get Todo By Id")]
        public async Task<ActionResult<Todo>> ReadTodo(int id)
        {
            var todo = await _dbContext.Todos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }


        [HttpPost ("Create Todo")]
        public ActionResult<Todo> CreateTodo(Todo todo)
        {
            _dbContext.Todos.Add (todo);
            _dbContext.SaveChanges();
            return Ok("Todos added successfully");
        }

        [HttpPut ("Update todos/{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] Todo updatedTodo)
        {
            var todo = _dbContext.Todos.Find(id);
            if(todo == null)
            {
                return NotFound ("Todo not found");
            }

            todo.Title = updatedTodo.Title;
            todo.Description = updatedTodo.Description;

            _dbContext.SaveChanges();
            return Ok("Todo updated successfully");
        }

        [HttpDelete ("remove-todo /{id}")]
        public IActionResult RemoveTodo(int id)
        {
            var todo = _dbContext.Todos.Find(id);
            if(todo == null)
            {
                return NotFound("Todo not found ");
            }
             _dbContext.Todos.Remove(todo);
            _dbContext.SaveChanges();
            return Ok("Todo removed successfully");
        }
    }
}
