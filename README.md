# Rent A Car Backend Project

This project is a multi-layered backend application developed using .NET Core. The aim of the project is to create a modular, flexible, and extensible architecture using N-layered architecture. Below are the technologies used and system features detailed.

## Technologies Used and Features

- **Entity Framework Core 7.0 Code First**: Used for database operations.
- **Generic Repository Pattern**: Provides a general structure for database operations.
- **Dependency Injection**: Reduces dependencies between components using dependency injection principle.
- **FluentValidation**: Used for input validations.
- **Autofac**: Used as an IoC Container, supports dependency injection, and provides opportunities for Aspect Oriented Programming (AOP).
- **Aspect Oriented Programming (AOP)**: Used for various cross-cutting concerns such as validation, caching, performance, and transaction management.
- **Cross Cutting Concerns**: Various cross-cutting concerns used in the project are managed within this structure.
- **Authentication & Authorization**: User identity authentication and authorization processes are implemented using ASP.NET Core Identity and JWT.
- **SOLID and CLEAN CODE Principles**: The project is developed following SOLID principles and focusing on writing clean code.

## Project Structure

The project has the following basic structure:

- **N-layered Architecture**: Consists of presentation, business, data access, and infrastructure layers.
- **Core Layer**: Provides an infrastructure that can be used independently of the project. Common components such as return type structures are included in this layer.
- **Business Engine**: A simple business engine is created to manage and organize business logic codes in the project.

## Installation

Follow the steps below to run the project:

1. Clone the repository: `git clone https://github.com/user/repo.git`
2. Install the necessary dependencies: `dotnet restore`
3. Update the database: `dotnet ef database update`
4. Start the application: `dotnet run`

## Usage

Provide a brief explanation of how the application can be used.

## Contributions

If you'd like to contribute, please submit a pull request. All contributions will be reviewed before acceptance.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). See the LICENSE file for details.
