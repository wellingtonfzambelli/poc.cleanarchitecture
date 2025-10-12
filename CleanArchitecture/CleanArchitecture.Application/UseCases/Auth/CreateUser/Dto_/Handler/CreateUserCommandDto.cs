using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed record CreateUserCommandDto : IRequest<CreateUserCommandResponseDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}