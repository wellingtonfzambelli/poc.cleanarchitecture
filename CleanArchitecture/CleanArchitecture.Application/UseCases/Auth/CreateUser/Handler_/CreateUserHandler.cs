using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Infrastructure.Cache;
using CleanArchitecture.Infrastructure.Cache.Model;
using CleanArchitecture.Infrastructure.Configuration;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserCommandDto, CreateUserCommandResponseDto>
{
    private readonly ICacheService _cacheService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateUserHandler> _logger;

    public CreateUserHandler(ICacheService cacheService, IUnitOfWork unitOfWork, ILogger<CreateUserHandler> logger)
    {
        _cacheService = cacheService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<CreateUserCommandResponseDto> Handle(CreateUserCommandDto request, CancellationToken cancellationToken)
    {
        _logger.LogWarning("starting handle method");

        var response = new CreateUserCommandResponseDto();

        if (_cacheService.GetByIdAsync<User>(request.Email).Result is not null)
        {
            response.SetError(new ErrorResponseDto(
                MessageValidation.NoDataFound.Code,
                MessageValidation.NoDataFound.Description
            ));
            return response;
        }

        var user = new User(request.FirstName, request.Email);
        await _unitOfWork.UserRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        await _cacheService.InsertAsync(new CreateUserCache
        {
            Id = user.Id,
            Email = user.Email,
            CreatedAt = DateTime.UtcNow
        });

        return response;
    }
}