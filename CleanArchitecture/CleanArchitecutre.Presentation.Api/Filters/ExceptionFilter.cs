using CleanArchitecture.Application.Shared;
using CleanArchitecture.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CleanArchitecture.Presentation.Api.Filters;

internal sealed class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExceptionFilter(ILogger<ExceptionFilter> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public void OnException(ExceptionContext context)
    {
        var correlationId = _httpContextAccessor?.HttpContext?.Request.Headers["correlation-id"].ToString();

        if (string.IsNullOrWhiteSpace(correlationId))
            correlationId = Guid.NewGuid().ToString();

        var exception = context.Exception;

        var problemDetails = new BadRequestDto
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7807",
            Title = MessageValidation.GeneralError.Description,
            Detail = exception.Message,
            Status = (int)HttpStatusCode.BadRequest,
            Instance = context.HttpContext.Request.Path,
            Errors = new List<ErrorResponseDto>
            {
                new ErrorResponseDto
                (
                    MessageValidation.GeneralError.Code,
                    MessageValidation.GeneralError.Description
                )
            },
        };

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };

        context.ExceptionHandled = true;
    }
}