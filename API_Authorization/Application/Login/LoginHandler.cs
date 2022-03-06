using API_Authorization.Exceptions;
using API_Authorization.Identity;
using API_Authorization.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace API_Authorization.Application
{
	public class LoginHandler : IRequestHandler<LoginQuery, UserModel>
	{
		private readonly UserManager<AppUser> _userManager;

		private readonly SignInManager<AppUser> _signInManager;
		private readonly IJwtGenerator _jwtGenerator;

		public LoginHandler(UserManager <AppUser> userManager,
									   SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
			
		}

		public async Task<UserModel> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new RestException(HttpStatusCode.Unauthorized);
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				return new UserModel
				{
					DisplayName = user.Displayname,
					Token = _jwtGenerator.CreateToken(user),
                    UserName = user.UserName,
					Image = null
				};
			}

			throw new RestException(HttpStatusCode.Unauthorized);
		}
	}
}
