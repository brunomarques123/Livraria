using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.AddUserCommand
{
    public class AddUserCommand : IRequest<ResultViewModel>
    {
        public AddUserCommand(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; set; }
        public string Email { get; set; }
    }
}
