namespace Library.Application.Models
{
    public class CreateLoanInputModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
