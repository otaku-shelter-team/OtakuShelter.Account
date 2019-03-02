using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Accounts
{
	public class AccountsExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IHttpContextAccessor accessor;
		private readonly IRabbitMqProducer<AccountsExceptionPayload> producer;
		private readonly AccountsConfiguration configuration;

		public AccountsExceptionHandler(
			IRabbitMqProducer<AccountsExceptionPayload> producer,
			IOptions<AccountsConfiguration> configuration,
			IHttpContextAccessor accessor)
		{
			this.producer = producer;
			this.configuration = configuration.Value;
			this.accessor = accessor;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new AccountsExceptionPayload
			{
				TraceId = accessor.HttpContext.TraceIdentifier,
				Type = exception.GetType().ToString(),
				Project = configuration.Name,
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {traceId = message.TraceId});
		}
	}
}