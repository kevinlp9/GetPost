using Microsoft.EntityFrameworkCore;

namespace Prueba.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; } 
    }
}
