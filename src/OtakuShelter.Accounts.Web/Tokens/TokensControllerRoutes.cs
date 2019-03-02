using Phema.Routing;

namespace OtakuShelter.Accounts
{
	public static class TokensControllerRoutes
	{
		public static IRoutingBuilder AddTokensController(this IRoutingBuilder builder, AccountsRoleConfiguration roles)
		{
			builder.AddController<TokensController>(controller =>
			{
				controller.AddRoute("tokens", c => c.Create(From.Body<CreateTokenRequest>()))
					.HttpPost();

				controller.AddRoute("tokens", c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("tokens/{tokenId}", c => c.Delete(From.Route<DeleteTokenRequest>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("tokens", c => c.Refresh(From.Body<RefreshTokenRequest>()))
					.HttpPut();

				controller.AddRoute("admin/tokens/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/tokens/{tokenId}",
						c => c.AdminDeleteById(From.Route<AdminDeleteByIdTokenRequest>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}