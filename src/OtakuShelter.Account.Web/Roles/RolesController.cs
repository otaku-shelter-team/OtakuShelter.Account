using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public class RolesController
	{
		private readonly AccountContext context;

		public RolesController(AccountContext context)
		{
			this.context = context;
		}

		public async Task AdminCreate(AdminCreateRoleViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<AdminReadRoleViewModel> AdminRead(FilterViewModel filter)
		{
			var model = new AdminReadRoleViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task AdminUpdate(int roleId, AdminUpdateRoleViewModel model)
		{
			await model.Update(context, roleId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDelete(AdminDeleteRoleViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}