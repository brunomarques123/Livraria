using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.AddLoanCommand
{
    public class AddLoanCommand : IRequest<ResultViewModel>
    {
        public AddLoanCommand(int userId, int bookId, DateTime loanDate, DateTime dueDate)
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = loanDate;
            DueDate = dueDate;
        }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
