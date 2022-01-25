using WebAPI.DbOperations;

namespace WebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == id);
            if (book is null)
                throw new Exception("Girmiş olduğunuz id ile eşleşen bir kayıt bulunamadı.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
