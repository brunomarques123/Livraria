using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public int UserId { get; set; }
    }
}
