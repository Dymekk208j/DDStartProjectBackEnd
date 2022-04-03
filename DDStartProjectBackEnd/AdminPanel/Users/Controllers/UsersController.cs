using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Controllers.Requests;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.AddBlockReasonIfNotExist;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Exceptions;
using DDStartProjectBackEnd.Common.Extensions;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request;
using DDStartProjectBackEnd.Common.Helpers.Logger;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Controllers
{
    [Route("api/AdminPanel/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UsersController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
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

        /// <summary>
        /// Block user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("BlockUser")]
        public async Task<ActionResult> BlockUser([FromBody] BlockUserRequest request)
        {
            try
            {
                await _mediator.Send(new BlockUserCommand(request.Id, request.Reason));

                if (request.SaveAsTemplate)
                {
                    var loggedUserId = this.GetLoggedUserId();
                    await _mediator.Send(new AddBlockReasonIfNotExistCommand(loggedUserId, request.Reason));
                }

                return Ok();
            }
            catch (RecordDuplicationException)
            {
                return Ok("BlockUser.BlockReasonNotSavedBecauseAlreadyExist");
            }
            catch (RecordNotFoundException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return BadRequest();
            }
        }
    }
}
