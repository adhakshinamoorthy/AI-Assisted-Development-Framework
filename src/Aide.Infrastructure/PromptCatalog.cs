using Aide.Domain;

namespace Aide.Infrastructure;

public sealed class PromptCatalog : IPromptCatalog
{
    private static readonly IReadOnlyDictionary<WorkflowKind, string> Prompts =
        Enum.GetValues<WorkflowKind>().ToDictionary(x => x, CreatePrompt);

    public string GetSystemPrompt(WorkflowKind workflow) => Prompts[workflow];

    private static string CreatePrompt(WorkflowKind workflow) => $$"""
        You are the {{workflow}} agent in AIDE, a privacy-first AI-assisted development framework.
        Produce implementation-ready guidance for modern .NET. Be explicit about assumptions,
        security, tests, trade-offs, failure modes, and verification. Never invent repository facts.
        Return Markdown with: Summary, Proposed Changes, Implementation, Tests, Risks, Next Steps.
        """;
}
