using Microsoft.Extensions.DependencyInjection;

using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Accounts
{
	public static class AccountsRabbitMqExtensions
	{
		public static IServiceCollection AddAccountsRabbitMq(
			this IServiceCollection services,
			AccountsRabbitMqConfiguration configuration)
		{
			services.AddPhemaJsonSerializer();
			
			var builder = services.AddPhemaRabbitMq(configuration.InstanceName,
				options =>
				{
					options.UserName = configuration.Username;
					options.Password = configuration.Password;
					options.Port = configuration.Port;
					options.HostName = configuration.Hostname;
					options.VirtualHost = configuration.VirtualHost;
				});
			
			builder.AddProducers(options =>
				options.AddProducer<AccountsExceptionPayload>("amq.direct", "errors")
					.Mandatory());
			
			return services;
		}
	}
}