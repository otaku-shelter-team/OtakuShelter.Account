using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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
			var account = new Account
			{
				Username = Username,
				PasswordHash = hasher.HashPassword(null, Password)
			};

			await context.Accounts.AddAsync(account);
		}
	}
}