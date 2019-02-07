using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Auth
{
	[DataContract]
	public class ReadIdentityResultViewModel
	{
		[DataMember(Name = "token")]
		public string Token { get; set; }

		public Task Load(Identity identity, AuthWebConfiguration configuration)
		{
			var key = Encoding.ASCII.GetBytes(configuration.Secret);
			var tokenHandler = new JwtSecurityTokenHandler();
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new [] 
				{
					new Claim(ClaimTypes.Name, identity.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = configuration.Issuer,
				Audience = configuration.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			
		 var token = tokenHandler.CreateToken(tokenDescriptor);
		 Token = tokenHandler.WriteToken(token);

			return Task.CompletedTask;
		}
	}
}