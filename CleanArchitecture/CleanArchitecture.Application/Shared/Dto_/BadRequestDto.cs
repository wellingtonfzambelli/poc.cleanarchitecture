using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Shared;

public sealed class BadRequestDto : ProblemDetails
{
    public IList<ErrorResponseDto> Errors { get; set; } = new List<ErrorResponseDto>();
}