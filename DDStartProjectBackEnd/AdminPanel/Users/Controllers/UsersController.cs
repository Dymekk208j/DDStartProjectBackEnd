using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Controllers
{
    [Route("api/AdminPanel/[controller]")]
    [ApiController]
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
        [HttpGet("GetUsersList")]
        [Authorize]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await _mediator.Send(new GetUsersListQuery());
        }
    }
}
