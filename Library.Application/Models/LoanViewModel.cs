using Library.Core.Entities;

namespace Library.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(int loanId, int userId, int bookId, DateTime loanDate, DateTime dueDate, DateTime? returnDate, bool isReturned)
        {
            LoanId = loanId;
            UserId = userId;
            BookId = bookId;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;
        }

        public int LoanId { get; set; } 
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        public static LoanViewModel FromEntity(Loan loan)
        {
            return new LoanViewModel(
                loan.Id, 
                loan.UserId,
                loan.BookId,
                loan.LoanDate,
                loan.DueDate,
                loan.ReturnDate,
                loan.IsReturned
            );
        }
    }
}
