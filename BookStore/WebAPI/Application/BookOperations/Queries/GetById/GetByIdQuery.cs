using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.Application.BookOperations.Queries.GetById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BooksDetailViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");

            BooksDetailViewModel viewModel = _mapper.Map<BooksDetailViewModel>(book);       
            //new BooksDetailViewModel()
            //{
            //    Genre = ((GenreEnum)book.GenreId).ToString(),
            //    PageCount = book.PageCount,
            //    PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
            //    Title = book.Title
            //};

            return viewModel;
        }

        public class BooksDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }


        }
    }
}
