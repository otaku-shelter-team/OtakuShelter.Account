using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Auth
{
	[DataContract]
	public class UpdateIdentityViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async Task Update(AuthContext context, int identityId, IPasswordHasher<Identity> hasher)
		{
			var identity = await context.Identities.FirstAsync(i => i.Id == identityId);

			if (Username != null)
			{
				identity.Username = Username;
			}

			if (Password != null)
			{
				identity.PasswordHash = hasher.HashPassword(identity, Password);
			}
		}
	}
}