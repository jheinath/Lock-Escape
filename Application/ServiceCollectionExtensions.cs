using Application.Commands;
using Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICreateGameCommand, CreateGameCommand>();
    }
}