using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Controllers
{
    [Route("api/AdminPanel/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all users from the API. 
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpPost("GetUsersList")]
        public async Task<BasicDataResponse<User>> GetUsersList([FromBody] BasicDataRequest request)
        {
            return await _mediator.Send(new GetUsersListQuery(request.StartRow, request.EndRow, request.SortModel, request.FilterModel));
        }
    }
}
