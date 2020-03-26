using System;
using System.Threading;
using InterviewTest.Application.Persons.Commands.CreatePerson;
using InterviewTest.Application.Tests.Infrastructure;
using MediatR;
using Moq;
using Xunit;

namespace InterviewTest.Application.Tests.Person.Commands.CreatePerson
{
    public class CreatePersonCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreatePersonCommandHandler(this._context);
            var fullname = "asad";
            var group = 1;
            // Act
            var result = sut.Handle(new CreatePersonCommand { Fullname = fullname, GroupId = group }, CancellationToken.None);

            // Assert
            Assert.Equal(4, result.Result);
        }
    }
}