using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InterviewTest.Application.DTO.Person;
using InterviewTest.Domain.Entities;

namespace InterviewTest.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(r => r.GroupName, src => src.MapFrom(r => r.Group.Name));
        }
    }
}
