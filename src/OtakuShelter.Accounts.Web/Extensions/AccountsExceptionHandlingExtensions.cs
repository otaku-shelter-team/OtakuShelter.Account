using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Accounts
{
	public static class AccountsExceptionHandlingExtensions
	{
		public static IServiceCollection AddAccountsExceptionHandling(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
					options.AddExceptionHandler<Exception, AccountsExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}