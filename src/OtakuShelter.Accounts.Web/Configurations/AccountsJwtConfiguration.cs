using System.Text;

using Microsoft.IdentityModel.Tokens;

using Phema.Configuration;

namespace OtakuShelter.Accounts
{
	[Configuration]
	public class AccountsJwtConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }

		public int MaxTokensCount { get; set; }
		
		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
	}
}