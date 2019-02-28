using Microsoft.Extensions.DependencyInjection;
using Phema.RabbitMq;
using Phema.Serialization;

namespace OtakuShelter.Account
{
	public static class AccountRabbitMqServices
	{
		public static IServiceCollection AddRabbitMqServices(
			this IServiceCollection services,
			AccountRabbitMqConfiguration configuration)
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
				options.AddProducer<ErrorQueueMessage>("amq.direct", "errors")
					.Mandatory());
			
			return services;
		}
	}
}