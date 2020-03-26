using MediatR;

namespace InterviewTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Fullname { get; set; }
        public int GroupId { get; set; }
    }
}