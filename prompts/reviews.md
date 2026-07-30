# Review prompts

## Code review

```text
Review this diff in repository context. Prioritize correctness, security, data loss,
concurrency, compatibility, performance, and missing tests. Report only actionable
findings with severity, file/line evidence, impact, and a concrete fix. Do not nitpick style.
```

## Security review

```text
Threat-model {{scope}}. Inspect trust boundaries, authentication, authorization, OWASP
Top 10 risks, injection, SSRF, secret handling, dependency/configuration risk, logging,
privacy, and abuse controls. Separate confirmed findings from hypotheses. Return severity,
evidence, exploit scenario, remediation, and verification. Do not include usable exploit code.
```

## Performance review

```text
Review {{scope}} for measured performance risks. Examine allocations, I/O, async flow,
query shape, contention, caching, backpressure, and load behavior. Require benchmarks or
traces before claiming improvement. Return suspected bottlenecks and an experiment plan.
```
