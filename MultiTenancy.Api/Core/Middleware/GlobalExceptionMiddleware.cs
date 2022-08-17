using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MultiTenancy.Application.Logging;
using System.Threading.Tasks;

namespace MultiTenancy.Api.Core.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                //if (ex is ForbiddenUseCaseException)
                //{
                //    statusCode = StatusCodes.Status403Forbidden;
                //}

                //if (ex is EntityNotFoundException)
                //{
                //    statusCode = StatusCodes.Status404NotFound;
                //}

                //if (ex is ValidationException e)
                //{
                //    statusCode = StatusCodes.Status422UnprocessableEntity;
                //    response = new
                //    {
                //        errors = e.Errors.Select(x => new
                //        {
                //            property = x.PropertyName,
                //            error = x.ErrorMessage
                //        })
                //    };
                //}

                //if (ex is UseCaseConflictException conflictEx)
                //{
                //    statusCode = StatusCodes.Status409Conflict;
                //    response = new { message = conflictEx.Message };
                //}

                if (ex is UnauthorizedAccessException unauthEx)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new { message = unauthEx.Message };
                }

                //if (ex is UnprocessableEntityException unprEx)
                //{
                //    statusCode = StatusCodes.Status422UnprocessableEntity;
                //    response = new { message = unprEx.Message };
                //}

                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
