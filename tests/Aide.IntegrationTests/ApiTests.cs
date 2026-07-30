using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Aide.IntegrationTests;

public sealed class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public ApiTests(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();
    [Fact] public async Task Workflows_ReturnsSupportedWorkflows() =>
        (await _client.GetFromJsonAsync<string[]>("/api/workflows", TestContext.Current.CancellationToken)).Should().Contain(["Architecture", "SecurityReview", "UnitTests"]);
    [Fact] public async Task Generate_RejectsUnknownWorkflow() =>
        (await _client.PostAsJsonAsync("/api/generate", new { workflow = "magic", goal = "build" }, TestContext.Current.CancellationToken)).StatusCode.Should().Be(HttpStatusCode.BadRequest);
}
