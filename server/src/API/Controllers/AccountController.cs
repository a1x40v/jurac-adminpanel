using Application.DTO.Account;
using Application.Features.Account.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticateResponse>> Login(AuthenticateQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}