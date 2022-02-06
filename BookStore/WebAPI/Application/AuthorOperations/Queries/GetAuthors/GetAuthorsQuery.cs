using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id);

            var obj = _mapper.Map<List<AuthorModel>>(authors);

            return obj;

        }
    }

    public class AuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
