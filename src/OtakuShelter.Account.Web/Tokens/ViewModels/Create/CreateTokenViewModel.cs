using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Account
{
	[DataContract]
	public class CreateTokenViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }

		public async Task<string> Create(
			AccountContext context,
			IPasswordHasher<Account> hasher,
			AuthWebConfiguration configuration)
		{
			var account = await context.Accounts.FirstAsync(i => i.Username == Username);

			var result = hasher.VerifyHashedPassword(account, account.PasswordHash, Password);

			if (result != PasswordVerificationResult.Success)
				throw new UnauthorizedAccessException();
			
			var secret = Encoding.ASCII.GetBytes(configuration.Secret);
			var tokenHandler = new JwtSecurityTokenHandler();
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new [] 
				{
					new Claim(ClaimTypes.Name, account.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = configuration.Issuer,
				Audience = configuration.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
			};
			
			var token = tokenHandler.CreateToken(tokenDescriptor);
			
			return tokenHandler.WriteToken(token);
		}
	}
}