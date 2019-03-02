using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class UpdateAccountRequest
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async ValueTask  Update(AccountsContext context, IPasswordHasher<Account> hasher, int accountId)
		{
			var account = await context.Accounts.FirstAsync(i => i.Id == accountId);

			if (Username != null)
			{
				account.Username = Username;
			}

			if (Password != null)
			{
				account.PasswordHash = hasher.HashPassword(account, Password);
			}
		}
	}
}