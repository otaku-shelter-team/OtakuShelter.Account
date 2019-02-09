using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class RolesControllerRoutes
	{
		public static IRoutingBuilder AddRolesController(this IRoutingBuilder builder)
		{
			builder.AddController<RolesController>("roles", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateRoleViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("{roleId}", c => c.Update(From.Route<int>(), From.Body<UpdateRoleViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute(c => c.Delete(From.Route<DeleteRoleViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}