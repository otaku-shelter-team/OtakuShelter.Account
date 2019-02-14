using Microsoft.AspNetCore.Identity;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class TokensControllerRoutes
	{
		public static IRoutingBuilder AddTokensController(this IRoutingBuilder builder)
		{
			builder.AddController<TokensController>(controller =>
			{
				controller.AddRoute("tokens", c => c.Create(From.Body<CreateTokenViewModel>()))
					.HttpPost();

				controller.AddRoute("tokens", c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("tokens/{tokenId}", c => c.Delete(From.Route<DeleteTokenViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("tokens", c => c.Refresh(From.Body<RefreshTokenViewModel>()))
					.HttpPut();

				controller.AddRoute("admin/tokens/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/tokens/{tokenId}",
						c => c.AdminDeleteById(From.Route<AdminDeleteByIdTokenViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}