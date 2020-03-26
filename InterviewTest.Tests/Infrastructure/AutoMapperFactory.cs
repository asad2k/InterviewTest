using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InterviewTest.Application.AutoMapper;

namespace InterviewTest.Application.Tests.Infrastructure
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonProfile());
                mc.AddProfile(new GroupProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
