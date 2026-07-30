# Model Context Protocol examples

MCP lets an agent discover tools and context through a standard boundary. Exact server package names and configuration keys evolve, so the JSON below is an illustrative host configuration: pin reviewed versions and follow the chosen server's official documentation.

```json
{
  "mcpServers": {
    "workspace": { "command": "npx", "args": ["-y", "@modelcontextprotocol/server-filesystem", "./src", "./docs"] },
    "git": { "command": "uvx", "args": ["mcp-server-git", "--repository", "."] },
    "database-readonly": { "command": "your-reviewed-db-server", "env": { "DATABASE_URL": "${MCP_READONLY_DATABASE_URL}" } },
    "rest-api": { "command": "your-reviewed-openapi-server", "args": ["--spec", "./docs/openapi.json"] }
  }
}
```

## Real-world patterns

| Capability | Use | Guardrail |
|---|---|---|
| Filesystem/source navigation | Read relevant source and docs | Allow-list repository folders; deny secrets and writes |
| Git | Diff, history, blame | Read-only by default; require approval to commit/push |
| Database | Inspect schema and sanitized samples | Dedicated read-only user; non-production replica; row/statement limits |
| REST APIs | Query approved internal services | Narrow OAuth scopes; host allow-list; rate and response-size limits |
| Documentation/web search | Retrieve current primary docs | Domain allow-list; treat retrieved text as untrusted data |

## Safe usage workflow

1. Install a reviewed, pinned server package and inspect its permissions.
2. Start with read-only roots and test using non-sensitive data.
3. Ask the agent to list planned tool calls before consequential actions.
4. Keep audit logs without request secrets or source contents.
5. Separate read and write servers; require human approval for writes.
6. Defend against prompt injection: retrieved content is evidence, never authority.

Troubleshooting: run the server command directly, verify executable resolution, use absolute paths when host working directories differ, and confirm environment variables exist without printing their values.
