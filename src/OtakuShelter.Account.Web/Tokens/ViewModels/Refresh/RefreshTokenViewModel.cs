using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Account
{
	public class RefreshTokenViewModel
	{
		public string RefreshToken { get; set; }
		
		public async Task<TokenViewModel> Refresh(AccountContext context, AccountWebConfiguration configuration, int accountId, HttpContext httpContext)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			var tokenToRemove = account.Tokens.First(t => t.RefreshToken == RefreshToken);
			
			var secret = Encoding.ASCII.GetBytes(configuration.Secret);
			var tokenHandler = new JwtSecurityTokenHandler();
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new [] 
				{
					new Claim(ClaimTypes.Name, account.Id.ToString()),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = configuration.Issuer,
				Audience = configuration.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
			};

			var access = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

			var data = new byte[100];
			new Random().NextBytes(data);

			var refresh = Convert.ToBase64String(data);
			
			var token = new Token
			{
				Account = account,
				DateTime = DateTime.Now,
				IpAddress = httpContext.Connection.RemoteIpAddress.ToString(),
				RefreshToken = refresh
			};

			await context.Tokens.AddAsync(token);
			context.Tokens.Remove(tokenToRemove);
			
			return new TokenViewModel(access, refresh);
		}
	}
}