using Aide.Application;
using Aide.Domain;
using Aide.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddAideApplication();
builder.Services.AddAideInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseExceptionHandler(handler => handler.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    var status = exception is ArgumentException ? StatusCodes.Status400BadRequest : StatusCodes.Status503ServiceUnavailable;
    await Results.Problem(statusCode: status, title: status == 400 ? "Invalid request" : "Local AI unavailable",
        detail: app.Environment.IsDevelopment() ? exception?.Message : null).ExecuteAsync(context);
}));

if (app.Environment.IsDevelopment()) app.MapOpenApi();
app.MapHealthChecks("/health");
app.MapGet("/api/workflows", () => TypedResults.Ok(Enum.GetNames<WorkflowKind>()));
app.MapPost("/api/generate", async Task<Results<Ok<GenerationResult>, ValidationProblem>>
    (GenerateDto input, IGenerationService service, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(input.Goal))
        return TypedResults.ValidationProblem(new Dictionary<string, string[]> { ["goal"] = ["Goal is required."] });
    if (!Enum.TryParse<WorkflowKind>(input.Workflow, true, out var workflow))
        return TypedResults.ValidationProblem(new Dictionary<string, string[]> { ["workflow"] = ["Unknown workflow."] });
    var result = await service.GenerateAsync(new(workflow, input.Goal, input.Context, input.Model), cancellationToken);
    return TypedResults.Ok(result);
});

app.Run();

public sealed record GenerateDto(string Workflow, string Goal, string? Context = null, string? Model = null);
public partial class Program;
