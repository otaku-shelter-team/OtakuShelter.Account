using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	public class DeleteAccountRequest
	{
		public async ValueTask  Delete(AccountsContext context, int accountId)
		{
			var account = await context.Accounts
				.Include(a => a.Tokens)
				.FirstAsync(i => i.Id == accountId);

			context.Accounts.Remove(account);
			context.Tokens.RemoveRange(account.Tokens);
		}
	}
}