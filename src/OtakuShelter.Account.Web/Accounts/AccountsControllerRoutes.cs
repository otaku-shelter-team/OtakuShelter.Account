using Microsoft.AspNetCore.Mvc.Authorization;
using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class AccountsControllerRoutes
	{
		public static IRoutingBuilder AddAccountsController(this IRoutingBuilder builder)
		{
			builder.AddController<AccountsController>("accounts", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateAccountViewModel>()))
					.HttpPost();

				controller.AddRoute(c => c.Read())
					.HttpGet()
					.AddFilter(new AuthorizeFilter());

				controller.AddRoute(c => c.Update(From.Body<UpdateAccountViewModel>()))
					.HttpPut()
					.AddFilter(new AuthorizeFilter());

				controller.AddRoute(c => c.Delete(From.Any<DeleteAccountViewModel>()))
					.HttpDelete()
					.AddFilter(new AuthorizeFilter());
			});
			
			return builder;
		}
	}
}