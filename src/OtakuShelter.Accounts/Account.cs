using System;
using System.Collections.Generic;

namespace OtakuShelter.Accounts
{
	public class Account
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; }
		public DateTime Created { get; set; }
		
		public virtual ICollection<Token> Tokens { get; set; }
	}
}