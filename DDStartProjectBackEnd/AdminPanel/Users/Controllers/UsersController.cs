using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Controllers.Requests;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request;
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
        public async Task<ServerRowsResponse<User>> GetUsersList([FromBody] ServerRowsRequest request)
        {
            return await _mediator.Send(new GetUsersListQuery(request));
        }

        /// <summary>
        /// Return user details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetUserDetails")]
        public async Task<UserDetails> GetUserDetails([FromQuery] GetUserDetailsRequest request)
        {
            return await _mediator.Send(new GetUserDetailsQuery(request.Id));
        }

        //[HttpPost]
        //public async Task BlockUser ([FromBody] BlockUserRequest request)
        //{
        //}
    }
}
