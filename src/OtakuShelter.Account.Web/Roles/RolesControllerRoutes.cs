using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class RolesControllerRoutes
	{
		public static IRoutingBuilder AddRolesController(this IRoutingBuilder builder)
		{
			builder.AddController<RolesController>("roles", controller =>
			{
				controller.AddRoute("admin", c => c.AdminCreate(From.Body<AdminCreateRoleViewModel>()))
					.HttpPost()
					.Authorize("admin");

				controller.AddRoute("admin", c => c.AdminRead(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{roleId}", c => c.AdminUpdate(From.Route<int>(), From.Body<AdminUpdateRoleViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute("admin/{roleId}", c => c.AdminDelete(From.Route<AdminDeleteRoleViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}