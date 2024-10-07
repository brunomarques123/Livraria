using Library.Application.Models;
using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;

namespace Library.Application.Commands.AddUserCommand
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return new ResultViewModel(false, "Username already exists.");
            }

            var user = new User(request.Username, request.Email);
            await _userRepository.AddAsync(user);

            return ResultViewModel.Success();
        }
    }
}
