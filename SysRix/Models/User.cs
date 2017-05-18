namespace SysRix.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Secret { get; set; }
        public string Domain { get; set; }
    }
}