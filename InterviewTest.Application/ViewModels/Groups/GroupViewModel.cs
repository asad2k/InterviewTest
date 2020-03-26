using System.Collections.Generic;
using InterviewTest.Application.DTO.Groups;

namespace InterviewTest.Application.ViewModels.Groups
{
    public class GroupViewModel
    {
        public IEnumerable<GroupDTO> Groups { get; set; }
    }
}