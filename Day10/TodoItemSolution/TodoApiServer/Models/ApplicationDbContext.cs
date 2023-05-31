using Microsoft.EntityFrameworkCore;

namespace TodoApiServer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // 없을시 DB와 연결이 안됨
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
