using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Commands.AddAuthor
{
    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.DateOfBirth).NotEmpty();
        }
    }
}
