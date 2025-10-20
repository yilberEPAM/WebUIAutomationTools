# AdvancedSynchronizationTests

This project demonstrates advanced synchronization techniques in Selenium WebDriver using C# and NUnit. It covers explicit waits, custom expected conditions, and fluent wait patterns to handle dynamic web content reliably.

## Features

- **Explicit Waits** with custom polling intervals
- **Custom Expected Conditions** for flexible synchronization
- **Fluent Wait simulation** in C#
- **Unit tests** with NUnit
- **Headless browser execution** for CI/CD compatibility

## Prerequisites

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- [Chrome browser](https://www.google.com/chrome/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or any compatible IDE

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/AdvancedSynchronizationTests.git
   cd AdvancedSynchronizationTests
   ```

2. **Install NuGet packages:**
   ```bash
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.WebDriver.ChromeDriver
   dotnet add package Selenium.Support
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Microsoft.NET.Test.Sdk
   ```

## Test URL

All tests use the following public page for dynamic content:
```
https://the-internet.herokuapp.com/dynamic_loading/1
```

## Running the Tests

- Open the solution in Visual Studio and build the project.
- Run tests via **Test Explorer** or with:
  ```bash
  dotnet test
  ```
