using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Aide.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aide.Infrastructure;

public sealed class OllamaLanguageModel(
    HttpClient client,
    IOptions<OllamaOptions> options,
    ILogger<OllamaLanguageModel> logger) : ILocalLanguageModel
{
    public async Task<ModelReply> GenerateAsync(string systemPrompt, string userPrompt, string? model, CancellationToken cancellationToken)
    {
        var selectedModel = string.IsNullOrWhiteSpace(model) ? options.Value.DefaultModel : model.Trim();
        var stopwatch = Stopwatch.StartNew();
        using var response = await client.PostAsJsonAsync("api/generate",
            new OllamaRequest(selectedModel, $"{systemPrompt}\n\n{userPrompt}", false), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            logger.LogWarning("Ollama returned {StatusCode}: {Body}", response.StatusCode, body);
            throw new HttpRequestException($"Ollama returned {(int)response.StatusCode}.", null, response.StatusCode);
        }

        var result = await response.Content.ReadFromJsonAsync<OllamaResponse>(cancellationToken)
            ?? throw new InvalidOperationException("Ollama returned an empty response.");
        return new(result.Response, result.Model, stopwatch.Elapsed);
    }

    private sealed record OllamaRequest(string Model, string Prompt, bool Stream);
    private sealed record OllamaResponse(
        [property: JsonPropertyName("response")] string Response,
        [property: JsonPropertyName("model")] string Model);
}
