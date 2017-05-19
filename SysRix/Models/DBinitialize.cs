using System;
using System.Linq;

namespace SysRix.Models
{
    public class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new SysRixDBContext();
            context.Database.EnsureCreated();

            if (context.Users.ToList().Count != 0) return;

            context.Users.Add(
                new User
                {
                    Username = "turnUser",
                    Secret = "wayk123!",
                    Domain = "wayk"
                }
            );

            context.SaveChanges();
        }
    }
}
