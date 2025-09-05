using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace PM.Common.Presentation.Middlewares;

public class TraceIdMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		var traceId = Activity.Current?.TraceId.ToString();

		if (!string.IsNullOrEmpty(traceId))
		{
			using (Serilog.Context.LogContext.PushProperty("TraceId", traceId))
			{
				await next(context);
			}	
		}
		else
		{
			await next(context);
		}
	}
}