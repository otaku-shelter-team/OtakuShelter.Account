using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

using Phema.Routing;

namespace OtakuShelter.Accounts
{
	public static class AccountsControllerRoutes
	{
		public static IRoutingBuilder AddAccountsController(this IRoutingBuilder builder, AccountsRoleConfiguration roles)
		{
			builder.AddController<AccountsController>(controller =>
			{
				controller.AddRoute("accounts", c => c.Create(From.Body<CreateAccountRequest>()))
					.HttpPost();

				controller.AddRoute("accounts", c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("accounts", c => c.Update(From.Body<UpdateAccountRequest>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("accounts", c => c.Delete(From.Any<DeleteAccountRequest>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/accounts", c => c.AdminRead(From.Query<FilterRequest>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}",
						c => c.AdminUpdateById(From.Route<int>(), From.Body<AdminUpdateByIdAccountRequest>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdAccountRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}