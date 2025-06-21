using System.Net;
using System.Text.Json;
using UniversidadQ10.Domain.Exceptions;

namespace UniversidadQ10.Web.Middleware
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;

        private static readonly Dictionary<Type, HttpStatusCode> StatusCodes = new()
        {
            { typeof(NotFoundException), HttpStatusCode.BadRequest },
            { typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized },
     
        };

        public AppExceptionHandlerMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción no controlada");

                if (IsHtmlRequest(context))
                {
                    context.Response.Redirect("/Home/Error?message=" + Uri.EscapeDataString(ex.Message));
                    return;
                }

                context.Response.StatusCode = GetStatusCodeForException(ex);
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    Error = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }

        private int GetStatusCodeForException(Exception ex)
        {
            return StatusCodes.TryGetValue(ex.GetType(), out var statusCode)
                ? (int)statusCode
                : (int)HttpStatusCode.InternalServerError;
        }

        private bool IsHtmlRequest(HttpContext context)
        {
            var accept = context.Request.Headers["Accept"].ToString();
            return accept.Contains("text/html");
        }
    }
}
