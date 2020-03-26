using System.Threading;
using System.Threading.Tasks;
using InterviewTest.Application.Persons.Commands.CreatePerson;
using InterviewTest.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InterviewTests.Api.Tests.Person
{
    public class CreateTests
    {
        [Fact]
        public async Task TestCreatePerson()
        {
            var mockMediatr = new Mock<IMediator>();
            mockMediatr.Setup(m => m.Send(It.IsAny<CreatePersonCommand>(), default(CancellationToken))).Returns(Task.FromResult(1));
            var controller = new PersonController(mockMediatr.Object);
            var command = new CreatePersonCommand { Fullname = "Asad", GroupId = 1 };

            var result = await controller.CreatePerson(command);

            OkObjectResult x = (OkObjectResult)result.Result;
            Assert.Equal(1, x.Value);
        }
    }
}