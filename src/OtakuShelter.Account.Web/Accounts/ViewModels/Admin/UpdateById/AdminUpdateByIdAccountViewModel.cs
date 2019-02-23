using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminUpdateByIdAccountViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "role")]
		public string Role { get; set; }

		public async Task Update(AccountContext context, IPasswordHasher<Account> hasher, AccountRoleConfiguration roles, int accountId)
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

			if (Role != null)
			{
				if(!roles.IsAny(Role))
					throw new InvalidOperationException();
				
				account.Role = Role;
			}
		}
	}
}