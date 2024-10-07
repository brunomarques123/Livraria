namespace Library.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        public User(string username, string email) : base()
        {
            Username = username;
            Email = email;
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
    }
}
