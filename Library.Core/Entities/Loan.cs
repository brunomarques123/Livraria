namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan() { }

        public Loan(int userId, int bookId, DateTime loanDate, DateTime dueDate,
                DateTime? returnDate, bool isReturned) : base()
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            IsReturned = isReturned;
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public bool IsReturned { get; private set; }

        public User User { get; private set; } 
        public Book Book { get; private set; } 

        public void MarkAsReturned(DateTime returnDate)
        {
            ReturnDate = returnDate;
            IsReturned = true;
        }
    }
}
