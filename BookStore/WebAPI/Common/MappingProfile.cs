using AutoMapper;
using WebAPI.BookOperations.GetBooks;
using static WebAPI.BookOperations.AddBook.AddBookCommand;
using static WebAPI.BookOperations.GetById.GetByIdQuery;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
