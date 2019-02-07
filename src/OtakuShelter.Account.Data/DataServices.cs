using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Account
{
	public static class DataServices
	{
		public static IServiceCollection AddDataServices(this IServiceCollection services, AccountContextConfiguration accountContext)
		{
			services.AddDbContextPool<AccountContext>(builder =>
				AccountContextFactory.ConfigureContext(builder, accountContext));
			
			return services;
		}
	}
}