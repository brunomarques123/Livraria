namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book() { }

        public Book(string title, string author, int publicationYear) : base()
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }

        public void Update(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
    }
}
