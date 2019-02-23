using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace OtakuShelter.Account
{
	public class AccountWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int MaxTokensCount { get; set; }

		public AccountRoleConfiguration Roles { get; set; }
		public AccountContextConfiguration Database { get; set; }

		public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
	}
}