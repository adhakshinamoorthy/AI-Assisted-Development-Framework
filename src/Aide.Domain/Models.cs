namespace Aide.Domain;

public enum WorkflowKind
{
    Architecture, Readme, UnitTests, Api, CodeReview, SecurityReview, Documentation,
    Refactoring, Performance, Requirements
}

public sealed record GenerationRequest(
    WorkflowKind Workflow,
    string Goal,
    string? Context = null,
    string? Model = null);

public sealed record GenerationResult(
    Guid Id,
    WorkflowKind Workflow,
    string Model,
    string Content,
    TimeSpan Duration,
    bool IsFallback);

public sealed record ModelReply(string Content, string Model, TimeSpan Duration);

public interface ILocalLanguageModel
{
    public Task<ModelReply> GenerateAsync(string systemPrompt, string userPrompt, string? model, CancellationToken cancellationToken);
}

public interface IPromptCatalog
{
    public string GetSystemPrompt(WorkflowKind workflow);
}
