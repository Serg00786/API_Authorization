using API_Authorization.Identity;
using MediatR;

namespace API_Authorization.Application
{
	public class LoginQuery : IRequest<UserModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
