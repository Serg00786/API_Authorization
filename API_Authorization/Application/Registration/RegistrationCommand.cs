using API_Authorization.Identity;
using MediatR;

namespace API_Authorization.Application.Registration
{
    public class RegistrationCommand : IRequest<UserModel>
    {
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
