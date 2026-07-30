# Testing strategy

The test pyramid separates deterministic orchestration tests from API contract tests and optional live infrastructure tests. Normal CI must not require Ollama or Docker. Add live tests behind `AIDE_RUN_OLLAMA_TESTS=true`; use Testcontainers for future database/message-broker adapters.

Run `dotnet test Aide.slnx`. For a manual local check, start Ollama, pull the configured model, run the API, call `/health`, then post the sample in the root README. Expected evidence is HTTP 200 with the selected local model and generated Markdown. First generation may take minutes while the model loads.
