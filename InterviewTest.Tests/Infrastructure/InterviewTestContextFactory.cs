using System;
using InterviewTest.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Application.Tests.Infrastructure
{
    public class InterviewTestContextFactory
    {
        public static InterviewTestDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InterviewTestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InterviewTestDbContext(options);

            context.Database.EnsureCreated();

            context.Groups.AddRange(new[]
            {
                new Domain.Entities.Group { Name = "Foo"},
                new Domain.Entities.Group { Name = "Bar"}
            });

            context.Persons.AddRange(new[] {
                new Domain.Entities.Person {Fullname = "Adam Cogan", GroupId = 1, DateTimeAdded = DateTime.Now },
                new Domain.Entities.Person { Fullname = "Jason Taylor",GroupId = 1, DateTimeAdded = DateTime.Now },
                new Domain.Entities.Person { Fullname = "Brendan Richards",GroupId =2, DateTimeAdded = DateTime.Now },
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(InterviewTestDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}