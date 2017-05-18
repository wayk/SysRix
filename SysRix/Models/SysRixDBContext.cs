using Microsoft.EntityFrameworkCore;

namespace SysRix.Models
{
    public class SysRixDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sysrix.db");
        }
    }

}