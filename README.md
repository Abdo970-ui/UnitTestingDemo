# UnitTestingDemo

[![.NET Tests](https://github.com/Abdo970-ui/UnitTestingDemo/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/Abdo970-ui/UnitTestingDemo/actions/workflows/dotnet.yml)

A small .NET project where I practice **Unit Testing** with xUnit and Moq.

## What's inside

- `MyApp`: simple classes (`Calculator`, `Student`, `StudentService`)
- `MyApp.Tests`: unit tests written with xUnit
- Mocking with Moq (`IStudentRepository`)
- CI with GitHub Actions: tests run automatically on every push

## Topics covered

- AAA pattern (Arrange, Act, Assert)
- `[Fact]` and `[Theory]` with `[InlineData]`
- Common Assert methods
- Edge cases
- Mocking with `Setup`, `Returns`, and `Verify`

## How to run

```bash
dotnet test
```

Requires .NET 10 SDK.
