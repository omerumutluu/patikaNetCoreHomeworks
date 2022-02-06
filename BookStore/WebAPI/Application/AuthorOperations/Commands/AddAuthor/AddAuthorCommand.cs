using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.AddAuthor
{
    public class AddAuthorCommand
    {
        public AddAuthorModel Model { get; set; }

        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public AddAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname && x.DateOfBirth == Model.DateOfBirth);

            if (author is not null)
                throw new InvalidOperationException("Bu bilgilere sahip bir yazar bulunmaktadır.");

            author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);
            _context.SaveChanges();

        }
    }

    public class AddAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
