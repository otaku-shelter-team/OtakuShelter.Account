using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class CreateAccountViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async Task Create(AccountContext context, IPasswordHasher<Account> hasher)
		{
			var role = await context.Roles.OrderBy(r => r.Id).FirstAsync();
			
			var account = new Account
			{
				Username = Username,
				PasswordHash = hasher.HashPassword(null, Password),
				Role = role,
				Created = DateTime.UtcNow
			};

			await context.Accounts.AddAsync(account);
		}
	}
}