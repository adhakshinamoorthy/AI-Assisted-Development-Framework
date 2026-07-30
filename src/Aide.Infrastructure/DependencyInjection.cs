using Aide.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Aide.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAideInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<OllamaOptions>().Bind(configuration.GetSection(OllamaOptions.SectionName))
            .Validate(x => x.Endpoint.Scheme is "http" or "https", "Ollama endpoint must use HTTP or HTTPS.")
            .Validate(x => x.TimeoutSeconds is > 0 and <= 600, "Timeout must be between 1 and 600 seconds.")
            .ValidateOnStart();
        services.AddSingleton<IPromptCatalog, PromptCatalog>();
        services.AddHttpClient<ILocalLanguageModel, OllamaLanguageModel>((provider, client) =>
        {
            var settings = provider.GetRequiredService<IOptions<OllamaOptions>>().Value;
            client.BaseAddress = settings.Endpoint;
            client.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds);
        });
        return services;
    }
}
