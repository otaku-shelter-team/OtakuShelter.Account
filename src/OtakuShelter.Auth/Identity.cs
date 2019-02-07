namespace OtakuShelter.Auth
{
	public class Identity
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
	}
}