using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminDeleteByIdAccountViewModel
	{
		[DataMember(Name = "accountId")]
		public int AccountId { get; set; }
		
		public async Task Delete(AccountContext context)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == AccountId);

			context.Accounts.Remove(account);
			context.Tokens.RemoveRange(account.Tokens);
		}
	}
}