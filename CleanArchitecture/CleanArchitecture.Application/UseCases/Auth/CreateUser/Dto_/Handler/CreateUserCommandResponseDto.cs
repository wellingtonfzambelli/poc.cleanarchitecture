using CleanArchitecture.Application.Shared;

namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed class CreateUserCommandResponseDto : ErrorBaseResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}