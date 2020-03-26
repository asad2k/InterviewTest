using InterviewTest.Application.DTO.Groups;
using InterviewTest.Domain.Entities;
using AutoMapper;

namespace InterviewTest.Application.AutoMapper
{
    public class GroupProfile: Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupDTO>()
                .ForMember(r => r.GroupName, src => src.MapFrom(r => r.Name));
        }
    }
}