using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecutre.Presentation.Api.Controllers.Base;

public abstract class CleanArchitectureBaseController : ControllerBase
{
    protected const string TrackId = "track-id";
    protected readonly IMediator Mediator;

    protected CleanArchitectureBaseController(IMediator mediator) =>
        Mediator = mediator;
}