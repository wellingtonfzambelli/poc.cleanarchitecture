using CleanArchitecture.Application.UseCases.Auth.CreateUser;
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

        services.AddScoped<IRequestHandler<CreateUserCommandDto, CreateUserCommandResponseDto>, CreateUserHandler>();
    }
}