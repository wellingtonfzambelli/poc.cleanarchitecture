using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Infrastructure.Cache;
using CleanArchitecture.Infrastructure.Cache.Model;
using CleanArchitecture.Infrastructure.Configuration;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.Auth.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserHandlerRequestDto, CreateUserHandlerResponseDto>
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

    public async Task<CreateUserHandlerResponseDto> Handle(CreateUserHandlerRequestDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("starting handle method");

        var response = new CreateUserHandlerResponseDto();

        if (_cacheService.GetByIdAsync<User>(request.Email).Result is not null)
        {
            response.SetError(new ErrorResponse(
                MessageValidation.NoDataFound.code,
                MessageValidation.NoDataFound.description
            ));
            return response;
        }

        var user = new User("", "");
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