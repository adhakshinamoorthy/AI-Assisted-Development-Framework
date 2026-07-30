using Aide.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Aide.Application;

public interface IGenerationService
{
    public Task<GenerationResult> GenerateAsync(GenerationRequest request, CancellationToken cancellationToken);
}

public sealed class GenerationService(ILocalLanguageModel model, IPromptCatalog prompts) : IGenerationService
{
    public async Task<GenerationResult> GenerateAsync(GenerationRequest request, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Goal);
        var systemPrompt = prompts.GetSystemPrompt(request.Workflow);
        var userPrompt = $"Goal:\n{request.Goal.Trim()}\n\nContext:\n{request.Context?.Trim() ?? "No additional context supplied."}";
        var reply = await model.GenerateAsync(systemPrompt, userPrompt, request.Model, cancellationToken);
        return new(Guid.NewGuid(), request.Workflow, reply.Model, reply.Content, reply.Duration, false);
    }
}

public static class DependencyInjection
{
    public static IServiceCollection AddAideApplication(this IServiceCollection services) =>
        services.AddSingleton<IGenerationService, GenerationService>();
}
