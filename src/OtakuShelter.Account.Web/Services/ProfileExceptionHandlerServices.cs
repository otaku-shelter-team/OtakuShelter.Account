using System;

using Microsoft.Extensions.DependencyInjection;

using Phema.ExceptionHandling;

namespace OtakuShelter.Account
{
	public static class ProfileExceptionHandlerServices
	{
		public static IServiceCollection AddExceptionHandlingServices(this IServiceCollection services)
		{
			return services.AddPhemaExceptionHandling(options =>
				options.AddExceptionHandler<Exception, AccountExceptionHandler>(e => true))
				.AddHttpContextAccessor();
		}
	}
}