# Troubleshooting

- **503 Local AI unavailable:** verify `ollama serve`, then `ollama list`; ensure the configured model is installed and port 11434 is reachable.
- **Request timeout:** raise `Ollama__TimeoutSeconds` up to 600 or choose a smaller quantized model.
- **Model not found:** set `Ollama__DefaultModel` to an exact installed tag.
- **Docker cannot reach Ollama:** use `host.docker.internal:11434`; ensure Ollama accepts the host connection under your local security policy.
- **MCP server does not start:** run its command directly and verify the pinned runtime/package and allow-listed paths.
- **Unsafe or incorrect output:** reduce supplied context, strengthen constraints, try a better-suited local model, and require human review. Never execute generated commands blindly.
