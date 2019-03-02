using System.Runtime.Serialization;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class TokenRequest
	{
		public TokenRequest(string accessToken, string refreshToken)
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