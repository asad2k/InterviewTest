using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InterviewTest.Application.DTO.Person;
using InterviewTest.Application.Interfaces;
using InterviewTest.Application.ViewModels.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Application.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, PersonsListViewModel>
    {
        private readonly IInterviewTestDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPersonsQueryHandler(IInterviewTestDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<PersonsListViewModel> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _context.Persons.OrderBy(p => p.PersonId).Include(r => r.Group).ToListAsync(cancellationToken);
            
            var model = new PersonsListViewModel
            {
                Persons = this._mapper.Map<IEnumerable<PersonDTO>>(persons)
            };

            return model;
        }
    }
}