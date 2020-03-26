using System.Threading;
using System.Threading.Tasks;
using InterviewTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Application.Interfaces
{
    public interface IInterviewTestDbContext
    {
        DbSet<Person> Persons { get; set; }

        DbSet<Group> Groups { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}