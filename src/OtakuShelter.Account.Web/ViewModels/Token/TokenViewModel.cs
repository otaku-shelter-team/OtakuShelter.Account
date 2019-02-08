using System.Runtime.Serialization;

namespace OtakuShelter.Account
{
	[DataContract]
	public class TokenViewModel
	{
		public TokenViewModel(string accessToken, string refreshToken)
		{
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
		
		[DataMember(Name = "accessToken")]
		public string AccessToken { get; set; }

		[DataMember(Name = "refreshToken")]
		public string RefreshToken { get; }
	}
}