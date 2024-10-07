using Library.Core.Entities;

namespace Library.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(int userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static UserViewModel FromEntity(User user)
        {
            return new UserViewModel(user.Id, user.Username, user.Email);
        }
    }
}
