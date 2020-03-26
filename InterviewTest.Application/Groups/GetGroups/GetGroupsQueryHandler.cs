using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InterviewTest.Application.DTO.Groups;
using InterviewTest.Application.Interfaces;
using InterviewTest.Application.ViewModels.Groups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Application.Groups.GetGroups
{
    internal class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, GroupViewModel>
    {
        private readonly IInterviewTestDbContext _context;
        private readonly IMapper _mapper;

        public GetGroupsQueryHandler(IInterviewTestDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<GroupViewModel> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _context.Groups.OrderBy(p => p.GroupId).ToListAsync(cancellationToken);

            var model = new GroupViewModel
            {
                Groups = this._mapper.Map<IEnumerable<GroupDTO>>(groups)
            };

            return model;
        }
    }
}