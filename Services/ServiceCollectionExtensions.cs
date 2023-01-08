using LockEscape.Services.EncodingToQueryParameters;

namespace LockEscape.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IGenerateQueryParametersService, GenerateQueryParametersService>();
    }
}