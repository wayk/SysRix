namespace SysRix.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Realm { get; set; }
        public string Domain { get; set; }
        public int Usage { get; set; }
    }
}