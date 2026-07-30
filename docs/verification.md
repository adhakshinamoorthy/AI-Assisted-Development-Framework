# Verification

CI restores locked NuGet dependencies, verifies formatting, builds in Release, runs deterministic unit/API tests without Ollama, audits transitive packages, and validates Compose configuration. A live Ollama generation is a manual check because model availability and hardware are environment-specific.

The automated suite does not evaluate answer correctness, prompt-injection resistance, model licenses, throughput, or GPU/CPU capacity. Publish those claims only with a dated evaluation dataset, model digest, hardware description, and measured results.
