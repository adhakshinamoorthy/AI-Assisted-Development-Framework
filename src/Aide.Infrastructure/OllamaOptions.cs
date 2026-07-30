namespace Aide.Infrastructure;

public sealed class OllamaOptions
{
    public const string SectionName = "Ollama";
    public Uri Endpoint { get; init; } = new("http://localhost:11434");
    public string DefaultModel { get; init; } = "qwen3:8b";
    public int TimeoutSeconds { get; init; } = 120;
}
