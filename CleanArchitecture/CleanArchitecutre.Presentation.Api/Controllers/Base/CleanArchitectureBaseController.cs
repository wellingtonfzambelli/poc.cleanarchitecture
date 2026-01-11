using CleanArchitecture.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecutre.Presentation.Api.Controllers.Base;

public abstract class CleanArchitectureBaseController : ControllerBase
{
    protected const string CorrelationId = "correlation-id";
    protected readonly IMediator Mediator;
    protected readonly ILogger<CleanArchitectureBaseController> Logger;

    protected CleanArchitectureBaseController(IMediator mediator, ILogger<CleanArchitectureBaseController> logger)
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