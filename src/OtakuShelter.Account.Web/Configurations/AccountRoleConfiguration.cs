
using System.Collections.Generic;

using Phema.Configuration;

namespace OtakuShelter.Account
{
	[Configuration]
	public class AccountRoleConfiguration
	{
		public string Admin { get; set; }
		public string User { get; set; }

		public bool IsAny(string role) => role == Admin || role == User;
	}
}