using System.Threading.Tasks;
using InterviewTest.Application.Groups.GetGroups;
using InterviewTest.Application.ViewModels.Groups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Presentation.Controllers
{
    [Route("api/data/[controller]")]
    public class GroupController : Controller
    {
        private readonly IMediator _mediatR;

        public GroupController(IMediator mediatR)
        {
            this._mediatR = mediatR;
        }

        [HttpGet]
        public async Task<ActionResult<GroupViewModel>> GetAll()
        {
            var result = await this._mediatR.Send(new GetGroupsQuery());

            return this.Ok(result);
        }
    }
}