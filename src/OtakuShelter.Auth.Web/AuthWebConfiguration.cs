namespace OtakuShelter.Auth
{
	public class AuthWebConfiguration
	{
		public string Secret { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		
		public AuthDatabaseConfiguration Database { get; set; }
	}
}