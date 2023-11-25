using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Todo_list
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Todo> Todos { get; set; }
    }
}
