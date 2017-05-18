using System;

namespace SysRix.Models
{
    public class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new SysRixDBContext();
            context.Database.EnsureCreated();
        }
    }
}
