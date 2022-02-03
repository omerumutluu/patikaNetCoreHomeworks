using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BookOperations.AddBook;
using WebAPI.BookOperations.DeleteBook;
using WebAPI.BookOperations.GetBooks;
using WebAPI.BookOperations.GetById;
using WebAPI.BookOperations.UpdateBook;
using WebAPI.DbOperations;
using static WebAPI.BookOperations.AddBook.AddBookCommand;
using static WebAPI.BookOperations.GetById.GetByIdQuery;

namespace WebAPI.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //        Id = 1,
        //        Title = "Lean Startup",
        //        GenreId = 1, //Personal Growth
        //        PageCount = 200,
        //        PublishDate = new DateTime(2022, 1, 24)
        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Title = "Herland",
        //        GenreId= 2, // Science Fiction
        //        PageCount = 250,
        //        PublishDate = new DateTime(2021, 6, 16)
        //    },
        //    new Book
        //    {
        //        Id = 3,
        //        Title = "Dune",
        //        GenreId= 2, // Science Fiction
        //        PageCount = 540,
        //        PublishDate = new DateTime(2020, 2, 14)
        //    }
        //};


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdQuery query = new GetByIdQuery(_context, _mapper);
            BooksDetailViewModel result;
            try
            {
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = _context.Books.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookModel newBook)
        {
            AddBookCommand command = new AddBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;

                AddBookCommandValidator validator = new AddBookCommandValidator();
                validator.ValidateAndThrow(command);
                
                //ValidationResult result = validator.Validate(command);
                
                //if (!result.IsValid)
                //{
                //    foreach (var error in result.Errors)
                //        Console.WriteLine("Özellik" + error.PropertyName + " - Error Message: " + error.ErrorMessage);
                //}
                //else
                //    command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookView updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            try
            {
                command.Model = updatedBook;
                command.BookId = id;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            try
            {
                command.BookId = id;
                
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
