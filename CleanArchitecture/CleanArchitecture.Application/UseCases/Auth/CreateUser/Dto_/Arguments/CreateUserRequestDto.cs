namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed record CreateUserRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}