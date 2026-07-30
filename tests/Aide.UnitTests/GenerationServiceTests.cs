using Aide.Application;
using Aide.Domain;
using FluentAssertions;
using Xunit;

namespace Aide.UnitTests;

public sealed class GenerationServiceTests
{
    [Fact]
    public async Task GenerateAsync_CombinesGoalAndContext()
    {
        var model = new RecordingModel();
        var result = await new GenerationService(model, new StubCatalog()).GenerateAsync(
            new(WorkflowKind.Architecture, "Design orders", "Use CQRS"), TestContext.Current.CancellationToken);
        result.Content.Should().Be("generated");
        model.UserPrompt.Should().Contain("Design orders").And.Contain("Use CQRS");
    }

    [Fact]
    public async Task GenerateAsync_RejectsBlankGoal()
    {
        var action = () => new GenerationService(new RecordingModel(), new StubCatalog())
            .GenerateAsync(new(WorkflowKind.Api, " "), TestContext.Current.CancellationToken);
        await action.Should().ThrowAsync<ArgumentException>();
    }

    private sealed class StubCatalog : IPromptCatalog { public string GetSystemPrompt(WorkflowKind workflow) => $"Act as {workflow}"; }
    private sealed class RecordingModel : ILocalLanguageModel
    {
        public string? UserPrompt { get; private set; }
        public Task<ModelReply> GenerateAsync(string systemPrompt, string userPrompt, string? model, CancellationToken cancellationToken)
        { UserPrompt = userPrompt; return Task.FromResult(new ModelReply("generated", "test-model", TimeSpan.Zero)); }
    }
}
