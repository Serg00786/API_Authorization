using API_Authorization.Application;
using API_Authorization.Application.Registration;
using API_Authorization.Identity;
using API_Authorization.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace API_Authorization.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        private readonly Parameters _Developments;

        public UserController(IOptions<Parameters> Developments)
        {
            _Developments = Developments.Value;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> LoginAsync(LoginQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<UserModel>> RegistrationAsync(RegistrationCommand command)
        {
            string options = _Developments.id;
            return await Mediator.Send(command);
        }
    }
}
