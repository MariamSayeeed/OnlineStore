using Domain.Exceptions;
using Shared.ErrorModels;

namespace OnlineStore_Api.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;


        public GlobalErrorHandlingMiddleware(RequestDelegate next , ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                // Log Exception
                _logger.LogError(ex , ex.Message);
                
                // 1. Set Status Code
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                // 2. Set Content Type  application/json
                context.Response.ContentType = "application/json";

                // 3. Response Object (Body)
                var response = new ErrorDetails()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };

                response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.StatusCode = response.StatusCode;

                // Return Response

                await context.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
