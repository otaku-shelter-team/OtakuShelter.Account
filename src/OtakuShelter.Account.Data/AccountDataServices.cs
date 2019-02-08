using Microsoft.Extensions.DependencyInjection;

namespace OtakuShelter.Account
{
	public static class AccountDataServices
	{
		public static IServiceCollection AddDataServices(this IServiceCollection services, AccountContextConfiguration accountContext)
		{
			services.AddDbContextPool<AccountContext>(builder =>
				AccountContextFactory.ConfigureContext(builder, accountContext));
			
			return services;
		}
	}
}