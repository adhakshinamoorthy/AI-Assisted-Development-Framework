# AIDE — AI-Assisted Development Engineering

A privacy-first reference implementation for using local language models across the software development lifecycle with .NET 10, C# 14, Ollama, reusable prompts, agent playbooks, and safe MCP patterns.

> AIDE accelerates engineering judgment; it does not replace it. Generated output can be incomplete, insecure, or wrong and must be reviewed and tested.

## What you can use today

- A runnable ASP.NET Core API for architecture, API, test, documentation, review, security, refactoring, performance, and requirements workflows.
- Local-only inference through Ollama—no silent cloud fallback.
- Curated [prompt](prompts/README.md), [instruction](instructions/dotnet-engineering.md), [agent](agents/README.md), and [MCP](mcp/README.md) libraries.
- Clean Architecture boundaries, typed configuration, validation, Problem Details, health checks, OpenAPI, unit tests, API tests, Docker, and CI.

## Quick start

Prerequisites: .NET SDK 10.0.302+, Ollama, and an installed model.

```powershell
ollama pull qwen3:8b
ollama serve
dotnet restore Aide.slnx
dotnet run --project src/Aide.Api
```

In a second terminal, use the URL printed by ASP.NET Core:

```powershell
$body = @{
  workflow = "Architecture"
  goal = "Design a modular order-processing API"
  context = "ASP.NET Core, PostgreSQL, 100 requests/second"
} | ConvertTo-Json
Invoke-RestMethod http://localhost:5000/api/generate -Method Post -ContentType application/json -Body $body
```

Use `GET /api/workflows`, `GET /health`, and—in Development—`GET /openapi/v1.json`. Override settings with `Ollama__Endpoint`, `Ollama__DefaultModel`, and `Ollama__TimeoutSeconds`.

## Repository map

```text
src/           Domain contracts, application workflows, Ollama adapter, HTTP API
tests/         Deterministic unit and API integration tests
prompts/       Architecture, coding, testing, review, security, performance, docs
instructions/  Reusable .NET, testing, and security standards
agents/        Nine specialist agent definitions and workflow contract
mcp/           Filesystem, git, database, REST, docs/web, navigation patterns
docs/          Architecture, model selection, testing, troubleshooting, roadmap
.github/       Build, test, and dependency-vulnerability CI
```

Read [architecture](docs/architecture.md), [model selection](docs/model-selection.md), [testing](docs/testing.md), and [troubleshooting](docs/troubleshooting.md).

## Docker

Keep Ollama on the trusted host, then run `docker compose up --build`. The API listens on `http://localhost:8080` and reaches Ollama through `host.docker.internal`. Do not expose this unauthenticated reference API to an untrusted network.

## AI-first workflow

1. Define a narrow goal and acceptance criteria.
2. Give the model only the minimum relevant, non-sensitive context.
3. Generate a proposal through the matching workflow.
4. Review assumptions, citations, security, licenses, and edge cases.
5. Apply small changes and prove them with build, tests, runtime checks, and human review.

Expected time savings depend on model, hardware, task clarity, repository size, and review depth. Measure lead time and defect escape rate in your own environment; do not treat generated-line count as productivity.

## Scope and limitations

This first release provides the working orchestration spine and reference content. It does not execute generated code, mutate repositories, authenticate users, index entire codebases, compare model performance automatically, or claim production readiness for internet exposure. Those capabilities require explicit sandboxing, tenancy, authorization, audit, evaluation, and threat modeling.

See the [roadmap](docs/roadmap.md), [contribution guide](CONTRIBUTING.md), [security policy](SECURITY.md), and [MIT license](LICENSE).

## FAQ

**Does source code leave my machine?** Not through AIDE's Ollama adapter. Optional MCP servers and any host tooling have their own trust boundaries and must be reviewed.

**Which model should I use?** Start with a model that fits your hardware, then evaluate it against representative tasks using the [selection guide](docs/model-selection.md).

**Can I use this API in production?** Use it as a reference. Add identity, authorization, abuse controls, secure network binding, durable audit/evaluation, and your organization's operational controls first.
