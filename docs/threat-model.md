# Threat model

## Assets

Source context, prompts, generated output, local model inventory, developer identity, and repository access are sensitive assets.

## Trust boundaries and controls

| Boundary | Primary threats | Current control | Required before shared deployment |
| --- | --- | --- | --- |
| Client to API | Oversized input, abuse, prompt injection | Request validation and bounded input | Identity, authorization, rate limits, quotas, TLS, audit |
| API to Ollama | Endpoint substitution, data disclosure, untrusted output | Typed local endpoint and no cloud fallback | Network allow-list, model provenance, encrypted transport where applicable |
| Model output to developer | Insecure or invented guidance | Explicit human-review contract | Evaluation gates, policy checks, provenance and approval workflow |
| Optional MCP tools | Excessive filesystem/network authority | Documentation-only allow-list pattern | Sandboxing, least privilege, consent, audit, secret filtering |

The API does not execute model output. Keep that separation: execution, repository mutation, and tool calls require separate authorization and isolation boundaries.
