using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Phema.ExceptionHandling;
using Phema.RabbitMq;

namespace OtakuShelter.Account
{
	public class AccountExceptionHandler : IExceptionHandler<Exception>
	{
		private readonly IRabbitMqProducer<ErrorQueueMessage> producer;
		private readonly IHttpContextAccessor accessor;

		public AccountExceptionHandler(IRabbitMqProducer<ErrorQueueMessage> producer, IHttpContextAccessor accessor)
		{
			this.producer = producer;
			this.accessor = accessor;
		}
		
		public async ValueTask<IActionResult> Handle(Exception exception)
		{
			var message = new ErrorQueueMessage
			{
				TraceId = accessor.HttpContext.TraceIdentifier,
				Type = exception.GetType().ToString(),
				Project = "account",
				Message = exception.Message,
				StackTrace = exception.StackTrace,
				Created = DateTime.UtcNow
			};

			await producer.Produce(message);
			
			return new BadRequestObjectResult(new {traceId = message.TraceId});
		}
	}
}