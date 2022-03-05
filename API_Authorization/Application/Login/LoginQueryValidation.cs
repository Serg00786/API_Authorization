using FluentValidation;

namespace API_Authorization.Application
{
	public class LoginQueryValidation : AbstractValidator<LoginQuery>
	{
		public LoginQueryValidation()
		{
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
