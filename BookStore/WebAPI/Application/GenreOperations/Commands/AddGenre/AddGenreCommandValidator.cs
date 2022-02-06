using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.AddGenre
{
    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Name).MinimumLength(4);
        }
    }
}
