using System.Runtime.Serialization;

namespace OtakuShelter.Account
{
	[DataContract]
	public class TokenViewModel
	{
		public TokenViewModel(string token)
		{
			Token = token;
		}
		
		[DataMember(Name = "token")]
		public string Token { get; set; }
	}
}