using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OtakuShelter.Auth
{
	[DataContract]
	public class CreateIdentityViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }


		public async Task Create(AuthContext context, IPasswordHasher<Identity> hasher)
		{
			var identity = new Identity
			{
				Username = Username,
				PasswordHash = hasher.HashPassword(null, Password)
			};

			await context.Identities.AddAsync(identity);
		}
	}
}