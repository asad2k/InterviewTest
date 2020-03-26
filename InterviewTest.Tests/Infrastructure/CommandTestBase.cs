using System;
using InterviewTest.Persistence;

namespace InterviewTest.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly InterviewTestDbContext _context;

        public CommandTestBase()
        {
            _context = InterviewTestContextFactory.Create();
        }

        public void Dispose()
        {
            InterviewTestContextFactory.Destroy(_context);
        }
    }
}
