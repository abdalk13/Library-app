namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            IsBorrowed = true;
        }

        public void Return()
        {
            IsBorrowed = false;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} - {(IsBorrowed ? "Borrowed" : "Available")}";
        }
    }
}
