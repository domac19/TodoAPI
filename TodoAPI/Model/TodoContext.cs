using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoAPI.Model
{
    public class TodoContext : IdentityDbContext
    {

        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
    }
}
