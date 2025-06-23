using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UniversidadQ10.Domain.Exceptions;

namespace UniversidadQ10.Web.Middleware
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;
        private readonly ITempDataDictionaryFactory _tempDataFactory;

        public AppExceptionHandlerMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger, ITempDataDictionaryFactory tempDataFactory)
        {
            _next = next;
            _logger = logger;
            _tempDataFactory = tempDataFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidateCreditsSubjectStudentException ex)
            {
                var tempData = _tempDataFactory.GetTempData(context);
                tempData["CoreBusinessError"] = ex.Message;
                tempData.Save();

                context.Response.Redirect("/Registration/Index");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Entidad no encontrada");
                context.Response.Redirect("/Home/Error?message=" + Uri.EscapeDataString(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción no controlada");
                context.Response.Redirect("/Home/Error?message=" + Uri.EscapeDataString(ex.Message));
            }
        }
    }
}
