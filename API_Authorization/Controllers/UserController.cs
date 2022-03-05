using API_Authorization.Application;
using API_Authorization.Application.Registration;
using API_Authorization.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Authorization.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> LoginAsync(LoginQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<UserModel>> RegistrationAsync(RegistrationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
