using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.GenreOperations.Commands.AddGenre
{
    public class AddGenreCommand
    {
        public AddGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public AddGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut.");

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class AddGenreModel
    {
        public string Name { get; set; }
    }
}
