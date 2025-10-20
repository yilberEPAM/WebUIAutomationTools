# CookieAutomationTests

This project demonstrates advanced cookie management automation using Selenium WebDriver and NUnit in C#. It includes unit tests for adding, editing, deleting, and listing cookies on a real, public test page.

## Features

- Automated browser tests with Selenium WebDriver (Chrome)
- Unit tests with NUnit
- Advanced cookie manipulation: add, edit, delete, list
- Headless browser execution for CI/CD compatibility

## Prerequisites

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- [Chrome browser](https://www.google.com/chrome/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) (recommended) or any compatible IDE

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/CookieAutomationTests.git
   cd CookieAutomationTests
   ```

2. **Install NuGet packages:**
   - Selenium.WebDriver
   - Selenium.WebDriver.ChromeDriver
   - NUnit
   - NUnit3TestAdapter
   - Microsoft.NET.Test.Sdk

   You can install them via the NuGet Package Manager or with the following command:
   ```bash
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.WebDriver.ChromeDriver
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Microsoft.NET.Test.Sdk
   ```

## Test URL

All tests use the following public page for cookie manipulation:
```
https://www.selenium.dev/selenium/web/cookies.html
```

## Running the Tests

- Open the solution in Visual Studio and build the project.
- Open the **Test Explorer** and run all tests.
- Or, run from the command line:
  ```bash
  dotnet test
  ```