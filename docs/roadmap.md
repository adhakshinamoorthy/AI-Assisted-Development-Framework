# Roadmap

## 0.1 - Reference core (implemented)

- Local Ollama generation API, workflow catalog, prompt/instruction/agent/MCP libraries
- Clean boundaries, validation, error mapping, health check, OpenAPI, tests, CI, Docker

## 0.2 - Context and evaluation

- Repository-aware context selection with secret filtering and token budgets
- Versioned evaluation dataset, model comparison CLI, quality/latency reports
- Streaming responses, cancellation verification, prompt provenance

## 0.3 - Safe generation

- Typed architecture/README/API/test output contracts and template rendering
- Sandboxed patch preview, policy checks, human approval, immutable audit trail
- Read-only MCP host with capability allow-lists and prompt-injection defenses

## 1.0 - Hardened platform reference

- Authentication, authorization, rate limits, tenancy, observability, and durable jobs
- Signed artifacts, SBOM/container scanning, and deployment examples
- Compatibility and performance baselines across supported local model families

Roadmap items are proposals, not commitments. Each requires design, threat modeling, tests, documentation, and measurable acceptance criteria.
