namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed record CreateUserResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}