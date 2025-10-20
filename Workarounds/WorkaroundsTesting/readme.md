# AdvancedWindowSessionDynamicTests

This project demonstrates advanced browser automation techniques using Selenium WebDriver and NUnit in C#.  
It covers:

- **Advanced Window Management:** Handling multiple windows/tabs and switching between them.
- **Session Control:** Managing cookies, verifying session persistence, and restarting browser sessions.
- **Working with Dynamic Elements:** Waiting for elements to appear/disappear and handling AJAX-driven content.

## Features

- Multi-window/tab management
- Cookie/session manipulation
- Explicit waits for dynamic content
- AJAX notification handling
- Headless browser execution for CI/CD

## Prerequisites

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- [Chrome browser](https://www.google.com/chrome/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or any compatible IDE

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/AdvancedWindowSessionDynamicTests.git
   cd AdvancedWindowSessionDynamicTests
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

## Running the Tests

- Open the solution in Visual Studio and build the project.
- Run tests via **Test Explorer** or with:
  ```bash
  dotnet test
  ```
