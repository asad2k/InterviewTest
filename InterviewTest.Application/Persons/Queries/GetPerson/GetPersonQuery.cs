using InterviewTest.Application.ViewModels.Persons;
using MediatR;

namespace InterviewTest.Application.Persons.Queries.GetPerson
{
    public class GetPersonQuery : IRequest<PersonsListViewModel>
    {
        public string Query { get; set; }
    }
}