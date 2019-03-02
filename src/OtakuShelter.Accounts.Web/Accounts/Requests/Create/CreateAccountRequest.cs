using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class CreateAccountRequest
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async ValueTask  Create(AccountsContext context, IPasswordHasher<Account> hasher, AccountsRoleConfiguration roles)
		{
			var account = new Account
			{
				Username = Username,
				PasswordHash = hasher.HashPassword(null, Password),
				Role = roles.User,
				Created = DateTime.UtcNow
			};

			await context.Accounts.AddAsync(account);
		}
	}
}