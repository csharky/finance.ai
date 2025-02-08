using Finance.Ai.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Finance.Ai.WebApi;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                Type: "ValidationFailure",
                Title: "Validation Error",
                Detail: "One or more validation failures have occurred.",
                Errors: validationException.Errors),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                Type: "Error",
                Title: "Internal Server Error",
                Detail: "An unexpected error occurred.",
                Errors: null)
        };
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Exception occured: {Message}", exception.Message);

        var details = GetExceptionDetails(exception);

        context.Response.StatusCode = details.StatusCode;

        await context.Response.WriteAsJsonAsync(details, cancellationToken: cancellationToken);
        
        return true;
    }
}

internal record ExceptionDetails(
    int StatusCode,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors);