# Contributing to Error 404 Not Lost

Thank you for your interest in contributing to Error 404 Not Lost! Here are some guidelines to help you get started.

## How to Report a Bug

- Ensure the bug has not already been reported by searching through the [issues](https://github.com/Namularbre/Error404NotLost/issues).
- If you cannot find an existing issue, open a new one with a clear description and steps to reproduce the bug.

## How to Propose a Feature

- Open an issue to discuss the new feature before starting work on it.
- Provide a detailed description of the feature and explain why it would be useful.

## Setting Up the Development Environment

1. Fork the repository and clone it locally.
2. Install the necessary dependencies by running `dotnet restore` (We use .NET 8 and the entity framework tool).
3. Build the project with `dotnet build`.

## Coding Conventions

- Follow the existing coding conventions in the project.
- Write clear and concise commit messages. Use the following format:
  - `feat: add a new feature`
  - `fix: fix a bug`
  - `docs: update documentation`
  - `style: fix formatting`
  - `refactor: refactor code`
  - `test: add tests`
  - `chore: general maintenance`
  - `save : to save your work on a remote branch (not master)`

**Use present in the commit message**

The name of the branch must match this format:
- `feature/version`
- `hotfix/issueid-version`

Version must increment the minor version for features and the patch version for bug fixes.
Exemple :

Start version is 1.0.0

A hotfix for issue 123 would be `hotfix/123-1.0.1`.
A new feature for version 1.1.0 would be `feature-name/1.1.0`. (or `feature-name/1.0.1` if the feature is realy basic)

## Submitting a Pull Request

1. Fork the repository and create a new branch for your feature or bug fix.
2. Make your changes and ensure that the tests pass.
3. Submit a pull request to the `master` branch of the main repository.
4. Wait for the code review and make necessary changes.

## Code Review

- All pull requests must be reviewed and approved by at least one project maintainer.
- Be open to feedback and ready to make changes if necessary.

Thank you for contributing to Error 404 Not Lost!
