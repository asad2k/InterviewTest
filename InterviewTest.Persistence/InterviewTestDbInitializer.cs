using System;
using System.Collections.Generic;
using System.Linq;
using InterviewTest.Domain.Entities;

namespace InterviewTest.Persistence
{
    public class InterviewTestDbInitializer
    {
        private readonly Dictionary<int, Person> Persons = new Dictionary<int, Person>();
        private readonly Dictionary<int, Group> Groups = new Dictionary<int, Group>();

        public static void Initialize(InterviewTestDbContext context)
        {
            var initializer = new InterviewTestDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(InterviewTestDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Persons.Any())
            {
                return; //the database has been seeded
            }

            SeedGroups(context);
            SeedPersons(context);
        }

        public void SeedGroups(InterviewTestDbContext context)
        {
            var groups = new[]
            {
                new Group { Name = "Foo"},
                new Group { Name = "Bar"}
            };

            context.Groups.AddRange(groups);
            context.SaveChanges();
        }

        public void SeedPersons(InterviewTestDbContext context)
        {
            var group1 = context.Groups.Where(r => r.GroupId == 1).FirstOrDefault();
            var group2 = context.Groups.Where(r => r.GroupId == 2).FirstOrDefault();

            var persons = new[]
            {
                new Person { GroupId = 1, Group = group1, Fullname = "Asad Mahmood", DateTimeAdded = DateTime.Now},
                new Person { GroupId = 1, Group =  group1, Fullname = "Ben Clarke", DateTimeAdded = DateTime.Now},
                new Person { GroupId = 2, Group = group2, Fullname = "Laura Smith", DateTimeAdded = DateTime.Now},
                new Person { GroupId = 2, Group = group2, Fullname = "Helen Hayes", DateTimeAdded = DateTime.Now},
                new Person { GroupId = 2, Group = group2, Fullname = "Robin Walker", DateTimeAdded = DateTime.Now}
            };

            context.Persons.AddRange(persons);
            context.SaveChanges();
        }
    }
}
