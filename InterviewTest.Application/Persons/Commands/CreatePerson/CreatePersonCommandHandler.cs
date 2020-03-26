using System;
using System.Threading;
using System.Threading.Tasks;
using InterviewTest.Application.Interfaces;
using InterviewTest.Domain.Entities;
using MediatR;

namespace InterviewTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IInterviewTestDbContext _context;

        public CreatePersonCommandHandler(IInterviewTestDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person
            {
                Fullname = request.Fullname,
                GroupId = request.GroupId,
                DateTimeAdded = DateTime.Now
            };

            this._context.Persons.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.PersonId;
        }
    }
}