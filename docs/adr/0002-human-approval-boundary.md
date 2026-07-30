# ADR 0002: Generated output remains advisory

Status: Accepted

The current API generates Markdown guidance and does not execute code or mutate repositories. Human review is the approval boundary. Future tool execution must add scoped authorization, sandboxing, diff review, secret filtering, audit evidence, and deterministic rollback.
