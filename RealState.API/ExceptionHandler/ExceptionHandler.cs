using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System.Reflection;

namespace RealState.API.ExceptionHandler
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception Ocurred : {Message}", exception.Message);

            ProblemDetails problems = new ProblemDetails();

            switch (exception)
            {
                default:
                    problems = new ProblemDetails()
                    {
                        Title = "Request Time Out",
                        Status = StatusCodes.Status408RequestTimeout,
                        Detail = " Please try again."
                    };

                    break;

                case BadRequestException badRequestException:
                    problems = new ProblemDetails
                    {
                        Title = "Bad Request",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = badRequestException.Message
                    };
                    _logger.LogError(exception.Message, "Bad Request Error Occurred");

                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                case UnauthorizedException unauthorizedException:

                    problems = new ProblemDetails()
                    {
                        Title = " UnAuthorized Exception",
                        Status = StatusCodes.Status401Unauthorized,
                        Detail = unauthorizedException.Message
                    };
                    _logger.LogError(exception.Message, "Not Authorized Error Ocurred ");
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;

                case NotFoundException notFoundException:
                    problems = new ProblemDetails()
                    {
                        Title = "Not Found",
                        Status = StatusCodes.Status404NotFound,
                        Detail = notFoundException.Message
                    };
                    _logger.LogError(exception.Message, "Not Found Exception Ocurred");
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
            }
            await httpContext.Response.WriteAsJsonAsync(problems, cancellationToken);
            return true;

        }

    }
}
