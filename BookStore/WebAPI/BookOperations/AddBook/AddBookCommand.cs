using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.AddBook
{
    public class AddBookCommand
    {
        public AddBookModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AddBookCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Bu kitap ismi zaten başka bir kitap için mevcut");

            book = _mapper.Map<Book>(Model);      //new Book();
            //book.Title = Model.Title;
            //book.PublishDate = Model.PublishDate;
            //book.PageCount = Model.PageCount;
            //book.GenreId = Model.GenreId;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class AddBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
