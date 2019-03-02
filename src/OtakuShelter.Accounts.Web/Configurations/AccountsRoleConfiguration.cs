using Microsoft.AspNetCore.Identity;

using Phema.Configuration;

namespace OtakuShelter.Accounts
{
	[Configuration]
	public class AccountsRoleConfiguration
	{
		public string Admin { get; set; }
		public string User { get; set; }

		public bool IsAny(string role) => role == Admin || role == User;
	}
}