using CleanArchitecture.Application.Mediator;
using CleanArchitecture.Application.Shared;
using CleanArchitecture.Application.UseCases.Auth.CreateUser;
using CleanArchitecture.Presentation.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CleanArchitecture.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController : CleanArchitectureBaseController
{
    public UserController(ISender mediator, ILogger<CleanArchitectureBaseController> logger)
        : base(mediator, logger) { }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateUserAsync
    (
        [FromBody]CreateUserRequestDto request,
        [FromHeader(Name = CorrelationId)][Required] Guid correlationId,
        CancellationToken ct
    )
    {
        var response = await Mediator.Send(
            new CreateUserCommandDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            },
        ct);

        if (response.IsValid())
            return Created(string.Empty, response);

        return base.GetBadRequest(response.GetErrors());
    }

    //  [HttpGet]
    //  [Route("all")]
    //  //[ProducesResponseType(typeof(DashboardResponseHandlerDto), (int)HttpStatusCode.OK)]
    //  //[ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    //  public async Task<IEnumerable<WeatherForecast>> GetAsync
    //(
    //    [FromHeader(Name = TrackId)][Required] Guid trackId,
    //    CancellationToken ct
    //)
    //  {
    //      //    var response = base.Mediator.Send(
    //      //new DashboardRequestHandlerDto(trackId),
    //      //ct);

    //      //    if (response.Result.IsValid())
    //      //        return Ok(response.Result);

    //      //    return BadRequest(response.Result.GetErrors());


    //      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //      {
    //          Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //          TemperatureC = Random.Shared.Next(-20, 55),
    //          Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //      })
    //      .ToArray();
    //  }
}