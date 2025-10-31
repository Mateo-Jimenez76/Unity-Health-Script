The basic format for your commit messages should be:

<type>[optional scope]: <description>

[optional body]

[optional footer(s)]

  
Key Commit Types
The type is the most important part for the changelog. By default, only feat and fix will appear in the final file.

feat (Features): Use this when you add a new feature.

Effect on changelog: Appears under a "Features" section.

Example: feat: allow users to upload a profile picture

fix (Bug Fixes): Use this when you fix a bug.

Effect on changelog: Appears under a "Bug Fixes" section.

Example: fix: correct password validation logic

Other common types (These usually do not appear in the changelog):

docs: For changes to documentation (e.g., README.md).

style: For code style changes (e.g., missing semicolons, formatting).

refactor: For code changes that neither fix a bug nor add a feature.

perf: For a code change that improves performance.

test: For adding or correcting tests.

chore: For build process, tooling, or dependency updates.
