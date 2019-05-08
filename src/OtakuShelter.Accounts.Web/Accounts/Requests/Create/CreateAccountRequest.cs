using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class CreateAccountRequest
	{
		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async ValueTask  Create(AccountsContext context, IPasswordHasher<Account> hasher, AccountsRoleConfiguration roles)
		{
			var account = new Account
			{
				Email = Email,
				Username = Username,
				PasswordHash = hasher.HashPassword(null, Password),
				Role = roles.User,
				Created = DateTime.UtcNow
			};

			await context.Accounts.AddAsync(account);
		}
	}
}