# Specialized agents

Agents share one safe workflow: gather evidence → state assumptions → propose a small plan → produce an artifact → verify → report limitations. Their prompts compose with the templates in [`prompts/`](../prompts/README.md).

| Agent | Purpose | Expected output |
|---|---|---|
| Requirements Analyzer | Turn ideas into testable scope | stories, rules, acceptance criteria, unknowns |
| Architecture | Select boundaries and trade-offs | diagrams, project tree, ADR candidates, risks |
| API Design | Design HTTP contracts | OpenAPI-oriented endpoints, errors, auth, examples |
| Unit Test | Characterize and test behavior | xUnit/FluentAssertions tests and gap report |
| Code Review | Find actionable defects | severity-ranked evidence and fixes |
| Security Review | Threat-model code/config | findings, mitigations, verification |
| Refactoring | Improve structure safely | behavior-preserving steps and tests |
| Performance Review | Find measurable bottlenecks | hypotheses, benchmarks, budgets |
| Documentation | Explain proven behavior | setup, usage, architecture, troubleshooting |

## Definition format

```yaml
name: Architecture Agent
purpose: Choose the simplest architecture satisfying proven drivers.
prompt: prompts/architecture.md
workflow: [inspect, clarify, compare, decide, diagram, verify]
expected_output: Markdown proposal plus ADR candidates
guardrails: [local-data-only, no-invented-facts, human-approval-required]
```

Example: submit `{"workflow":"SecurityReview","goal":"Review the upload endpoint","context":"<relevant local source>"}` to the API, review each cited claim, then apply accepted changes in a separate commit.
