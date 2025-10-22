module.exports = {
  // This configuration extends the standard "angular" preset.
  // We are essentially just adding a new section for 'refactor' commits.
  types: [
    { type: 'feat', section: 'Features' },
    { type: 'fix', section: 'Bug Fixes' },
    { type: 'chore', hidden: true }, // These won't be in the changelog
    { type: 'docs', hidden: true },
    { type: 'style', hidden: true },
    { type: 'refactor', section: 'Code Refactoring', hidden: false }, // THIS IS THE NEW LINE
    { type: 'perf', section: 'Performance Improvements', hidden: false },
    { type: 'test', hidden: true }
  ]
};
