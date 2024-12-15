using End_Point_Parameters_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace End_Point_Parameters_Task
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
  
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
