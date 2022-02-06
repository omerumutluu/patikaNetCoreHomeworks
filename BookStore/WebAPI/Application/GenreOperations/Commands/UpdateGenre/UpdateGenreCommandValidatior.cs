using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatior : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidatior()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}
