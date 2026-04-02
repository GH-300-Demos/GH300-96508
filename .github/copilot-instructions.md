# Data model classes

- All the data model classes should be in a specific folder called `Models` within the main source directory.
- Each data model class should be defined in its own file, and the file name should match the class name.
- Use PascalCase for naming data model classes (e.g., `UserProfile`, `OrderItem`).
- Each data model class should include properties that represent the data fields, along with appropriate data types
- Include constructor methods to initialize the properties of the data model classes.
- Implement getter and setter methods for each property to encapsulate access to the data fields.
- Every time a class has an ID property, it should be named `Id` and be of type `int`. Never use GUID or string for ID properties in data model classes.


# Language format

- When you write an if statement, always use curly braces `{}` even for single-line statements.
- When you write an if statement, always put the open curly brace on the same line as the if condition.
- When you create a calculated property, always use the `get` keyword and write the code inside the getter method.
- Use camelCase for variable and function names (e.g., `userName`, `getUserData`).
- When you write a throw statement, always use the old style method (with the throw keyword on the same line as the Error object).