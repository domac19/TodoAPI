using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TodoAPI.Authentication;

namespace TodoAPI.Model
{
    public class TodoContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
    }
}
