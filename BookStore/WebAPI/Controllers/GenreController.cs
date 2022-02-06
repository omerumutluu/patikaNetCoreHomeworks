using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.GenreOperations.Commands.AddGenre;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);

            var obj = query.Handle();

            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);

            query.GenreId = id;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();

            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] AddGenreModel newGenre)
        {
            AddGenreCommand command = new AddGenreCommand(_context);

            command.Model = newGenre;

            AddGenreCommandValidator validator = new AddGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);

            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreCommandValidatior validator = new UpdateGenreCommandValidatior();

            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
