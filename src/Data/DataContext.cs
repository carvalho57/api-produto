using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
    }
}