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

		public async Task Create(CreateRoleViewModel model)
		{
			await model.Create(context);

			await context.SaveChangesAsync();
		}

		public async Task<ReadRoleViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadRoleViewModel();

			await model.Load(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task Update(int roleId, UpdateRoleViewModel model)
		{
			await model.Update(context, roleId);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteRoleViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}