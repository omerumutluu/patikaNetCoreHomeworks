using AutoMapper;
using WebAPI.Application.AuthorOperations.Commands.AddAuthor;
using WebAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebAPI.Application.AuthorOperations.Queries.GetAuthors;
using WebAPI.Application.BookOperations.Queries.GetBooks;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.Entities;
using static WebAPI.Application.BookOperations.Commands.AddBook.AddBookCommand;
using static WebAPI.Application.BookOperations.Queries.GetById.GetByIdQuery;

namespace WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<AddAuthorModel,Author>();
            CreateMap<UpdateAuthorModel, Author>();
            CreateMap<Author, AuthorModel>();
            CreateMap<Author, AuthorDetailModel>();
        }
    }
}
