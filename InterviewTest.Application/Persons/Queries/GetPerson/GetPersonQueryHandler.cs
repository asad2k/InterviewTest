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

namespace InterviewTest.Application.Persons.Queries.GetPerson
{
    internal class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonsListViewModel>
    {
        private readonly IInterviewTestDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IInterviewTestDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<PersonsListViewModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var persons = await (from p in _context.Persons
                                 join g in _context.Groups on p.GroupId equals g.GroupId
                      where p.Fullname.ToLower().Contains(request.Query.ToLower()) || g.Name.ToLower().Contains(request.Query.ToLower())
                      select p).Include(r => r.Group).ToListAsync(cancellationToken);

            var model = new PersonsListViewModel
            {
                Persons = this._mapper.Map<IEnumerable<PersonDTO>>(persons)
            };

            return model;
        }
    }
}