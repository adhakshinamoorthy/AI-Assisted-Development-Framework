# ADR 0001: No silent cloud fallback

Status: Accepted

AIDE uses an explicit local language-model adapter and returns a sanitized service-unavailable response when it cannot reach Ollama. It does not send prompts to a cloud provider automatically. Additional providers must be explicit, separately configured, and covered by data-handling policy.
