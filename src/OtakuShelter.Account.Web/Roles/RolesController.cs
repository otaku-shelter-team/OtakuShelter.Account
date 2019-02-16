using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public class RolesController : ControllerBase
	{
		private readonly AccountContext context;

		public RolesController(AccountContext context)
		{
			this.context = context;
		}

		public async Task<ReadRoleViewModel> Read(FilterViewModel filter)
		{
			var model = new ReadRoleViewModel();

			await model.Read(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task<ReadByIdRoleViewModel> ReadById(int roleId)
		{
			var model = new ReadByIdRoleViewModel();

			await model.ReadById(context, roleId);

			return model;
		}
		
		public async Task AdminCreate(AdminCreateRoleViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			await model.Create(context, accountId);

			await context.SaveChangesAsync();
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