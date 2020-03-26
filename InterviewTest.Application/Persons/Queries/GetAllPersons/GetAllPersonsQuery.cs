using InterviewTest.Application.ViewModels.Persons;
using MediatR;

namespace InterviewTest.Application.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<PersonsListViewModel>
    {
    }
}