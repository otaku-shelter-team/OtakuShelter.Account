using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

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
					.Authorize();

				controller.AddRoute(c => c.Update(From.Body<UpdateAccountViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute(c => c.Delete(From.Any<DeleteAccountViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin", c => c.AdminRead(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{accountId}",
						c => c.AdminUpdateById(From.Route<int>(), From.Body<AdminUpdateByIdAccountViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/{accountId}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdAccountViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}