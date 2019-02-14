using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OtakuShelter.Account
{
	public class AccountsController : ControllerBase
	{
		private readonly AccountContext context;
		private readonly IPasswordHasher<Account> hasher;

		public AccountsController(AccountContext context, IPasswordHasher<Account> hasher)
		{
			this.context = context;
			this.hasher = hasher;
		}

		public async Task Create(CreateAccountViewModel model)
		{
			await model.Create(context, hasher);

			await context.SaveChangesAsync();
		}

		public async Task<ReadAccountViewModel> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var model = new ReadAccountViewModel();

			await model.Read(context, accountId);

			return model;
		}

		public async Task Update(UpdateAccountViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Update(context, hasher, accountId);

			await context.SaveChangesAsync();
		}
		
		public async Task Delete(DeleteAccountViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<AdminReadAccountViewModel> AdminRead(FilterViewModel filter)
		{
			var model = new AdminReadAccountViewModel();

			await model.Read(context, filter.Offset, filter.Limit);

			return model;
		}

		public async Task<AdminReadByIdAccountViewModel> AdminReadById(int accountId)
		{
			var model = new AdminReadByIdAccountViewModel();

			await model.Read(context, accountId);

			return model;
		}
		
		public async Task AdminUpdateById(int accountId, AdminUpdateByIdAccountViewModel model)
		{
			await model.Update(context, hasher, accountId);

			await context.SaveChangesAsync();
		}

		public async Task AdminDeleteById(AdminDeleteByIdAccountViewModel model)
		{
			await model.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}