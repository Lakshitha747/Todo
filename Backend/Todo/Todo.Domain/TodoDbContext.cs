using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;

namespace Todo.Domain
{
    internal class TodoDbContext : IdentityDbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<TodoTask> Tasks { get; set; }
    }
}
