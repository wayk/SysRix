using System.Collections.Generic;

namespace SysRix.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(long id);
        User FindMatch(string name, string secret, string domain);
        void Remove(long id);
        void Update(User item);
    }
}