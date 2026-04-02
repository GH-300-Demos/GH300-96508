---
description: 'Baseline JavaScript/TypeScript coding standards and best practices.'
applyTo: '**/*.js, **/*.mjs, **/*.cjs, **/*.ts, **/*.tsx, **/*.jsx'
---

# JavaScript/TypeScript Baseline Standards

## File and Module Organization

- Use **ES6 modules** (`import`/`export`) by default instead of CommonJS (`require`/`module.exports`).
- One primary class or component per file; the file name should match the exported entity name.
- Group related functionality into modules and use index files for clean imports.
- Use `.js` for JavaScript files, `.ts` for TypeScript files, `.jsx` for React JavaScript components, and `.tsx` for React TypeScript components.

## Naming Conventions

- **Variables and functions**: Use `camelCase` (e.g., `userName`, `fetchUserData`).
- **Constants**: Use `UPPER_SNAKE_CASE` for true constants (e.g., `MAX_RETRY_COUNT`, `API_BASE_URL`).
- **Classes and components**: Use `PascalCase` (e.g., `UserProfile`, `OrderProcessor`, `ShoppingCart`).
- **Private fields**: Use `#` prefix for private class fields (e.g., `#internalState`).
- **Files**: Use `kebab-case` for file names (e.g., `user-profile.js`, `order-processor.ts`).
- **Boolean variables**: Prefix with `is`, `has`, `should`, or `can` (e.g., `isActive`, `hasPermission`, `shouldValidate`).

## Code Style and Formatting

- Use **2 spaces** for indentation (not tabs).
- Always use **semicolons** to terminate statements.
- Use **single quotes** (`'`) for strings by default; use backticks (`` ` ``) for template literals.
- Maximum line length: **100 characters** (prefer breaking long lines into multiple lines).
- Always use `const` by default; use `let` only when reassignment is needed. **Never use `var`**.
- Place opening braces `{` on the same line as the statement (K&R style).

## Control Flow

- Always use **curly braces** `{}` for `if`, `for`, `while`, and other control structures, even for single-line statements.
- Prefer **early returns** to reduce nesting levels.
- Use **strict equality** (`===` and `!==`) instead of loose equality (`==` and `!=`).
- Avoid using `switch` statements with fall-through; use explicit `break` or `return` for each case.

```javascript
// Good
if (condition) {
  doSomething();
}

// Bad
if (condition)
  doSomething();
```

## Functions

- Prefer **arrow functions** for anonymous functions and callbacks.
- Use **named functions** for top-level function declarations for better stack traces.
- Use **default parameters** instead of checking for undefined.
- Destructure function parameters when accepting objects.
- Keep functions small and focused on a single responsibility.

```javascript
// Good
const fetchUserData = async (userId, { includeDetails = false } = {}) => {
  // implementation
};

// Also good for top-level declarations
async function processOrder(order) {
  // implementation
}
```

## Async/Await

- Prefer **async/await** over raw Promises for better readability.
- Always use `try/catch` blocks with async/await for error handling.
- Never use naked `await` without proper error handling.
- Use `Promise.all()` for parallel async operations.

```javascript
// Good
async function fetchData() {
  try {
    const result = await apiCall();
    return result;
  } catch (error) {
    console.error('Failed to fetch data:', error);
    throw error;
  }
}
```

## Error Handling

- Always throw **Error objects**, never throw strings or plain objects.
- Provide meaningful error messages that describe what went wrong and why.
- Use custom error classes for domain-specific errors.
- Never silently catch and ignore errors without logging.

```javascript
// Good
throw new Error('User ID must be a positive integer');

// Also good
class ValidationError extends Error {
  constructor(message) {
    super(message);
    this.name = 'ValidationError';
  }
}
```

## Objects and Arrays

- Use **object literal** syntax for creating objects (`{}` not `new Object()`).
- Use **array literal** syntax for creating arrays (`[]` not `new Array()`).
- Use **destructuring** for extracting values from objects and arrays.
- Use **spread operator** (`...`) for copying objects and arrays.
- Use **object shorthand** for property names when possible.

```javascript
// Good
const user = { name, email, age };
const updatedUser = { ...user, verified: true };
const [first, ...rest] = items;
```

## Modern JavaScript Features

- Use **template literals** for string interpolation instead of concatenation.
- Use **optional chaining** (`?.`) to safely access nested properties.
- Use **nullish coalescing** (`??`) instead of `||` when you specifically want to check for `null` or `undefined`.
- Use **array methods** (`map`, `filter`, `reduce`, `find`, `some`, `every`) instead of traditional loops when working with arrays.

```javascript
// Good - template literals
const message = `Hello, ${user.name}!`;

// Good - optional chaining
const city = user?.address?.city;

// Good - nullish coalescing
const port = config.port ?? 3000;
```

## TypeScript-Specific (when using TypeScript)

- Always define **explicit types** for function parameters and return values.
- Use **interfaces** for object shapes; use **type aliases** for unions, intersections, or primitives.
- Enable **strict mode** in `tsconfig.json`.
- Avoid using `any` type; use `unknown` if the type is truly unknown and perform type checks.
- Use **enums** for sets of named constants when appropriate.

```typescript
// Good
interface User {
  id: number;
  name: string;
  email: string;
}

function getUserById(id: number): Promise<User> {
  // implementation
}
```

## Comments and Documentation

- Write **self-documenting code** with clear variable and function names.
- Use **JSDoc comments** for documenting functions, especially public APIs.
- Comment the **why**, not the **what** (the code should show what it does).
- Keep comments up to date when code changes.

```javascript
/**
 * Fetches user data from the API and enriches it with profile information.
 * @param {number} userId - The unique identifier for the user
 * @param {Object} options - Additional options
 * @param {boolean} options.includeProfile - Whether to include profile data
 * @returns {Promise<User>} The user object with enriched data
 */
async function fetchUserData(userId, options = {}) {
  // implementation
}
```

## Testing

- Write **unit tests** for all business logic and utility functions.
- Use descriptive test names that explain what is being tested and expected outcome.
- Follow the **Arrange-Act-Assert** pattern in test structure.
- Mock external dependencies in unit tests.

## Common Patterns

- **ID fields**: When a class or object has an ID property, name it `id` (lowercase) and use type `number` or `string` consistently throughout the project. Never mix types for IDs.
- **Configuration**: Store configuration in environment variables and load them using a centralized config module.
- **Exports**: Always prefer **named exports** over default exports for better refactoring support.
- **Imports**: Group imports in the following order:
  1. External dependencies (from `node_modules`)
  2. Internal modules (from within the project)
  3. Types/interfaces (if using TypeScript)

```javascript
// Good - named exports
export const fetchUserData = async (userId) => { /* ... */ };
export const validateEmail = (email) => { /* ... */ };

// Import grouping
import express from 'express';
import { Database } from 'better-sqlite3';

import { logger } from './utils/logger.js';
import { authMiddleware } from './middleware/auth.js';

import type { User, Order } from './types.js';
```
