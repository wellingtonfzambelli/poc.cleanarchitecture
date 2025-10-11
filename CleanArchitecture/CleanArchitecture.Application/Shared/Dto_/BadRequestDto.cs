namespace CleanArchitecture.Application.Shared;

public sealed class BadRequestDto
{
    public string Code { get; set; }
    public string Message { get; set; }
}