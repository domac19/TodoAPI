using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Model;
using NodaTime;

namespace TodoAPI
{
    public partial class TodoData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new TodoContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                if (dbContext.Todos.Any())
                {
                    return;
                }
                dbContext.Todos.AddRange(
                     new Todo
                     {
                         Id = 1,
                         Name = "Jabuke",
                         Completed = true,
                         DateCreated = DateTime.Now
                     },
                         new Todo
                         {
                             Id = 2,
                             Name = "Banane",
                             Completed = true,
                             DateCreated = DateTime.Now
                         });
                dbContext.SaveChanges();
            }
        }
    }
}
