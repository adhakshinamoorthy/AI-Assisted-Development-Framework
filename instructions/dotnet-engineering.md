# .NET engineering instructions

- Use .NET 10 and C# 14; keep nullable reference types enabled.
- Prefer cohesive vertical slices with dependency direction toward the domain.
- Make invalid states hard to represent with records, enums, and validated value objects.
- Use async end-to-end for I/O and propagate `CancellationToken`.
- Use dependency injection at composition roots; avoid service locators and static state.
- Return RFC 9457 Problem Details; never expose stack traces or secrets.
- Use structured logs with stable event names. Never log credentials, tokens, or prompt data by default.
- Add XML docs to public reusable APIs where the name and contract are insufficient.
- Optimize only from measurements. Keep changes small, reviewable, and reversible.
