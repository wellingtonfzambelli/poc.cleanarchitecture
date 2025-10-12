using CleanArchitecture.Application.UseCases.Auth.CreateUser;
using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Infrastructure.Cache;
using CleanArchitecture.Infrastructure.Repositories.Shared;
using CleanArchitecture.Infrastructure.Repositories.UserAggregate;
using FluentValidation;
using MediatR;

namespace CleanArchitecutre.Presentation.Api.DI.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // instead use one by one like this: services.AddAutoMapper(typeof(AuthConfigurationMapping));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICacheService, CacheService>();

        services.AddScoped<IRequestHandler<CreateUserCommandDto, CreateUserCommandResponseDto>, CreateUserHandler>();
    }
}