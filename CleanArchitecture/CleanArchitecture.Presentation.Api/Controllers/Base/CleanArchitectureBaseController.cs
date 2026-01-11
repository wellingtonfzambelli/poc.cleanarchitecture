using CleanArchitecture.Application.Mediator;
using CleanArchitecture.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Api.Controllers.Base;

public abstract class CleanArchitectureBaseController : ControllerBase
{
    protected const string CorrelationId = "correlation-id";
    protected readonly ISender Mediator;
    protected readonly ILogger<CleanArchitectureBaseController> Logger;

    protected CleanArchitectureBaseController(ISender mediator, ILogger<CleanArchitectureBaseController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    protected IActionResult GetBadRequest(IList<ErrorResponseDto> errors) =>
        BadRequest(new BadRequestDto
        {
            Title = "Bad Request",
            Status = StatusCodes.Status400BadRequest,
            Instance = HttpContext.Request.Path,
            Errors = errors
        });
}