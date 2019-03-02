namespace OtakuShelter.Accounts
{
	public class AccountsConfiguration
	{
		public string Name { get; set; }
		public string Version { get; set; }
		
		public AccountsDatabaseConfiguration Database { get; set; }
		public AccountsJwtConfiguration Jwt { get; set; }
		public AccountsRabbitMqConfiguration RabbitMq { get; set; }
		public AccountsRoleConfiguration Roles { get; set; }
	}
}