using System;
using System.Collections.Generic;
using System.Text;
using InterviewTest.Application.ViewModels.Groups;
using MediatR;

namespace InterviewTest.Application.Groups.GetGroups
{
    public class GetGroupsQuery : IRequest<GroupViewModel>
    {

    }
}
