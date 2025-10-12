using CleanArchitecture.Application.UseCases.Auth.CreateUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.DI;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // instead use one by one like this: services.AddAutoMapper(typeof(AuthConfigurationMapping));        

        services.AddScoped<IRequestHandler<CreateUserCommandDto, CreateUserCommandResponseDto>, CreateUserHandler>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}