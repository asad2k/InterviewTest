using InterviewTest.Application.Interfaces;
using InterviewTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Persistence
{
    public class InterviewTestDbContext : DbContext, IInterviewTestDbContext
    {
        public InterviewTestDbContext(DbContextOptions<InterviewTestDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}