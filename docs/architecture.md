# Architecture

```mermaid
flowchart LR
  Dev[Developer / AI client] --> API[Aide.Api]
  API --> App[Aide.Application]
  App --> Domain[Aide.Domain]
  Infra[Aide.Infrastructure] --> Domain
  API --> Infra
  Infra --> Ollama[(Local Ollama)]
  MCP[MCP servers] -. optional context .-> Dev
```

The API is the composition root and HTTP boundary. Application owns use-case orchestration. Domain owns stable contracts and has no framework dependency. Infrastructure owns Ollama HTTP and prompt selection. This Clean Architecture core uses vertical slices at the endpoint/workflow level without adding mediator ceremony.

## Generation sequence

```mermaid
sequenceDiagram
  participant C as Client
  participant A as API
  participant S as GenerationService
  participant O as Ollama
  C->>A: POST /api/generate
  A->>A: Validate contract
  A->>S: GenerationRequest
  S->>S: Select system prompt
  S->>O: /api/generate (stream=false)
  O-->>S: local model response
  S-->>C: GenerationResult
```

Ollama unavailability maps to a sanitized 503. The framework does not silently substitute cloud inference. Generated text is untrusted: a human must review it before code, configuration, or operational use.

## Extending

Add a `WorkflowKind`, prompt, and tests for a new workflow. Implement `ILocalLanguageModel` to support another local engine. Keep vendor JSON and transport concerns inside Infrastructure.
