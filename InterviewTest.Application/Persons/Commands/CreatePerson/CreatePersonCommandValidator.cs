using FluentValidation;

namespace InterviewTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Fullname).NotNull().NotEmpty();
            RuleFor(x => x.GroupId).GreaterThan(0);
        }
    }
}