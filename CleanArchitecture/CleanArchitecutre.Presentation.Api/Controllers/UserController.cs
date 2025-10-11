using CleanArchitecutre.Presentation.Api.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecutre.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController : CleanArchitectureBaseController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("all")]
    //[ProducesResponseType(typeof(DashboardResponseHandlerDto), (int)HttpStatusCode.OK)]
    //[ProducesResponseType(typeof(BadRequestDto), (int)HttpStatusCode.BadRequest)]
    public async Task<IEnumerable<WeatherForecast>> GetAsync
    (
        [FromHeader(Name = TrackId)][Required] Guid trackId,
        CancellationToken ct
    )
    {
        //    var response = base.Mediator.Send(
        //new DashboardRequestHandlerDto(trackId),
        //ct);

        //    if (response.Result.IsValid())
        //        return Ok(response.Result);

        //    return BadRequest(response.Result.GetErrors());


        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}