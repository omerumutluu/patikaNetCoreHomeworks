using WebAPI.DbOperations;

namespace WebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == BookId);
            if (book is null)
                throw new Exception("Kitap bulunamadı.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
