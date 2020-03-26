using System.Threading.Tasks;
using InterviewTest.Application.Persons.Commands.CreatePerson;
using InterviewTest.Application.Persons.Queries.GetAllPersons;
using InterviewTest.Application.Persons.Queries.GetPerson;
using InterviewTest.Application.ViewModels.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Presentation.Controllers
{
    [Route("api/data/[controller]")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediatR;

        public PersonController(IMediator mediatR)
        {
            this._mediatR = mediatR;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            var personId = await this._mediatR.Send(createPersonCommand);

            return this.Ok(personId);
        }

        [HttpGet]
        public async Task<ActionResult<PersonsListViewModel>> GetAll()
        {
            var result = await this._mediatR.Send(new GetAllPersonsQuery());

            return this.Ok(result);
        }

        [HttpGet]
        [Route("getPersonByNameOrGroupName")]
        public async Task<ActionResult<PersonsListViewModel>> GetPerson(GetPersonQuery model)
        {
            var result = await this._mediatR.Send(model);

            return this.Ok(result);
        }
    }
}