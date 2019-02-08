using System.Collections.Generic;

namespace OtakuShelter.Account
{
	public class Account
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }

		public virtual ICollection<Token> Tokens { get; set; }
	}
}