using System;
using System.Collections;
using System.Collections.Generic;

namespace OtakuShelter.Account
{
	public class Account
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; }
		public DateTime Created { get; set; }
		
		public virtual ICollection<Token> Tokens { get; set; }
	}
}