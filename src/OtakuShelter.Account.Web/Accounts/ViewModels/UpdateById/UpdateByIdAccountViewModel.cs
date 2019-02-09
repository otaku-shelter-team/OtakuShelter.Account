using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	public class UpdateByIdAccountViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "roleId")]
		public int? RoleId { get; set; }

		public async Task Update(AccountContext context, IPasswordHasher<Account> hasher, int accountId)
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

			if (RoleId != null)
			{
				var role = await context.Roles.FirstAsync(r => r.Id == RoleId);

				account.Role = role;
			}
		}
	}
}