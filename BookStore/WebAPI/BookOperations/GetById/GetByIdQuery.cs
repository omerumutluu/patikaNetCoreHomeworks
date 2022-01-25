using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _context;

        public GetByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BooksViewModel Handle(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();

            BooksViewModel viewModel = new BooksViewModel()
            {
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                Title = book.Title
            };

            return viewModel;
        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }


        }
    }
}
