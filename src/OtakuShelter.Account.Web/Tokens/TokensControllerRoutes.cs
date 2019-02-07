using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class TokensControllerRoutes
	{
		public static IRoutingBuilder AddTokensController(this IRoutingBuilder builder)
		{
			builder.AddController<TokensController>("tokens", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateTokenViewModel>()))
					.HttpPost();
			});
			
			return builder;
		}
	}
}