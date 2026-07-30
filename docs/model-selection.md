# Local model selection

Model tags and capabilities change. Confirm the exact model license, context window, hardware requirements, and Ollama tag before adoption.

| Family | Good starting use | Trade-off |
|---|---|---|
| Qwen coder/instruct | code and structured engineering tasks | larger variants need more memory |
| Llama instruct | general reasoning and documentation | coding quality varies by size |
| Mistral | balanced local workflows | check model-specific license |
| DeepSeek coder | code generation/review | validate resource use and provenance policy |
| Phi | laptops and quick iterations | smaller capacity on complex repository context |

Benchmark on your own tasks. Track correctness after human review, latency to first/complete response, tokens per second, memory, energy, and failure rate. Use a small model for classification/routing and a stronger model for architecture or security analysis. Never call a faster answer “better” without quality evaluation.
