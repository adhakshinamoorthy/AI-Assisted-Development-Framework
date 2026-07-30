# Testing and security instructions

- Test behavior and public contracts, not private implementation.
- Unit tests must be deterministic and offline. Gate live Ollama tests behind an explicit flag.
- Use Testcontainers for infrastructure integration; skip with a clear reason if Docker is absent.
- Cover authorization failures, validation boundaries, cancellation, and error mapping.
- Apply least privilege, deny by default, validate at trust boundaries, and parameterize data access.
- Keep secrets out of source, prompts, logs, fixtures, and screenshots. Use user-secrets or environment variables.
- Run dependency and container scans in CI; triage results rather than suppressing them globally.
