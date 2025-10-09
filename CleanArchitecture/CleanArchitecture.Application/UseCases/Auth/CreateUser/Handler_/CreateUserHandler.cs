using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Domain.Shared;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequestDto, CreateUserResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponseDto> Handle(CreateUserRequestDto request, CancellationToken cancellationToken)
    {
        var user = new User("", "");

        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateUserResponseDto
        {

        };
    }
}