namespace OtakuShelter.Account
{
	public class AccountWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int MaxTokensCount { get; set; }
		
		public AccountContextConfiguration Database { get; set; }
	}
}