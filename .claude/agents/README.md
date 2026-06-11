# Claude Code Subagents

Two reusable developer personas for use with [Claude Code](https://code.claude.com/docs).
They are **polyglot** — they adapt to whatever stack a project uses rather than
imposing one — and both carry product/UX sensibility.

| Agent | Use it for | Stacks it knows |
| --- | --- | --- |
| **`frontend-developer`** | UI components, pages, styling, design systems, client state, forms, accessibility, responsive/mobile, animation, Figma-to-code, frontend reviews | React/Next.js · Blazor/.NET · Angular · Vue/Nuxt |
| **`backend-developer`** | APIs, business logic, data models & migrations, SQL/query performance, auth, jobs, integrations, observability, backend reviews | ASP.NET Core/C# · Supabase/Postgres · Node.js/TS · Python (FastAPI/Django) |

## How to use

Claude will often delegate to these automatically based on the task. You can
also invoke one explicitly:

```
> use the frontend-developer agent to build the dashboard header
> have the backend-developer add a paginated /api/orders endpoint
```

List and manage them anytime with the `/agents` command.

## Scope

These live in `.claude/agents/`, so they are **project-scoped** and shared with
anyone who clones this repo. To make them available across *all* your projects,
copy the two `.md` files into `~/.claude/agents/` on your machine.

## Customizing

Each agent is a Markdown file with YAML frontmatter:

- `name` / `description` — the description drives when Claude auto-delegates.
- `model` — `inherit` (matches your main session) by default; set to
  `sonnet` / `haiku` for cheaper/faster runs, or `opus` for max capability.
- `tools` — omitted here, so each agent inherits all available tools
  (including the Figma, Supabase, Vercel, etc. MCP servers). Add a
  comma-separated list to restrict.

Edit the body to encode your team's conventions, then commit.
