using Phema.Configuration;

namespace OtakuShelter.Account
{
	[Configuration]
	public class AccountRoleConfiguration
	{
		public string Admin { get; set; }
		public string User { get; set; }
	}
}