# Coding, refactoring, and API prompts

## Implement a vertical slice

```text
Implement {{capability}} in the supplied .NET repository. Follow existing conventions.
Include contracts, validation, authorization, cancellation, structured logging,
Problem Details, OpenAPI, pagination/filtering where applicable, and focused tests.
List files changed and exact verification commands. Never weaken security or tests.
```

## Refactor safely

```text
Refactor {{scope}} to improve {{goal}} without changing observable behavior.
First characterize behavior with tests. Identify duplication, coupling, SOLID issues,
and compatibility risks. Produce small reversible steps and show proof after each step.
```

## Bug fix

```text
Diagnose {{symptom}}. Reproduce the actual runtime path, identify the first causal fault,
add a regression test, implement the smallest fix, and report evidence and residual risk.
```
