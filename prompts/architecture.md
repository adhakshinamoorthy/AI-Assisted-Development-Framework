# Architecture prompts

## Architecture decision

```text
Act as a pragmatic .NET architect. Design {{system}} for {{users/load}}.
Drivers: {{quality attributes}}. Constraints: {{constraints}}.
Compare Clean Architecture, vertical slices, modular monolith, microservices, CQRS,
and event-driven approaches only where relevant. Recommend the simplest adequate option.
Return: assumptions, context diagram (Mermaid), projects/dependencies, folder tree,
data/consistency model, security boundaries, deployment, ADRs, risks, and verification plan.
Do not invent requirements. Mark unknowns and ask up to five blocking questions.
```

## Architecture generator

Use the prompt above with `Workflow=Architecture`. Treat its output as a proposal, not executable truth; record accepted decisions as ADRs.
