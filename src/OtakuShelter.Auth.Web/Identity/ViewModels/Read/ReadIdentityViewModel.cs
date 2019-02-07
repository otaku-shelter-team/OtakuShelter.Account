using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace OtakuShelter.Auth
{
	[DataContract]
	public class ReadIdentityViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async Task<Identity> Read(AuthContext context, IPasswordHasher<Identity> hasher)
		{
			var identity = await context.Identities.FirstAsync(i => i.Username == Username);

			var result = hasher.VerifyHashedPassword(identity, identity.PasswordHash, Password);

			return result == PasswordVerificationResult.Success
				? identity
				: null;
		}
	}
}