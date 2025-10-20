# **Cross-Browser Testing Framework with Selenium, C# and NUnit**

## **Project Overview**
This repository contains a highly modular and extensible framework for automated cross-browser testing using Selenium WebDriver, NUnit, and C#. It is designed for testing web applications across multiple browsers and supports dynamic configuration through a JSON file. The test results are automatically logged and exported to an HTML report using ExtentReports.

---

## **Features**
- **Cross-Browser Testing**: Execute tests in Chrome, Firefox, and Edge.
- **Page Object Model (POM)**: Encapsulation of page-specific methods and elements for cleaner tests.
- **ExtentReports Integration**: Generate detailed, interactive HTML reports for test results.
- **Dynamic Configuration**: Manage environment variables (URL, browsers, timeout settings) through a `config.json` file.
- Support for **NUnit Framework**, a powerful and widely-used testing framework for .NET.
- Easy setup and execution with CLI commands or Visual Studio Test Explorer.
- Flexible browser selection through CLI parameters.

---

## **Project Structure**

```plaintext
CrossBrowser/
│
├── Pages/                        # Page Object Model Implementation
│   ├── BasePage.cs               # Reusable methods for all Pages
│   ├── LoginPage.cs              # Specific implementations for Login Page
│
├── Utilities/                    # Utilities and helper classes
│   ├── BrowserConfig.cs          # WebDriver and browser setup
│   ├── ExtentManager.cs          # Configuration for ExtentReports
│   └── TestBase.cs               # Base methods for all tests (SetUp, TearDown)
│
├── Configuration/                # Configuration files
│   ├── config.json               # JSON file for dynamic settings
│
├── TestsScripts/                 # Test scripts
│   ├── Tests.cs                  # Contains login-related tests
│
├── Reports/                      # Output folder for ExtentReports HTML
│
├── .gitignore                    # Git ignore file
├── README.md                     # Project documentation
├── CrossBrowser.csproj           # Project configuration file

```

---

## **Getting Started**

### **Prerequisites**
- Install **.NET SDK** (minimum version: 6.0 or later) from [here](https://dotnet.microsoft.com/download).
- Install **Visual Studio** (Community Edition or higher) with the required workloads:
  - **ASP.NET and web development**
  - **.NET desktop development**
  - **Testing tools**
- Install the supported browsers (Chrome, Firefox, or Edge) on your system.
- Ensure the following drivers are installed:
  - **ChromeDriver** (Auto-installed using NuGet).
  - **GeckoDriver** (For Firefox — can also be added via NuGet).
  - **EdgeDriver** (For Edge — can also be added via NuGet).

---

### **Setup**

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo-name/cross-browser-testing.git
   ```

2. Navigate to the project folder:
   ```bash
   cd cross-browser-testing
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Verify that the required browsers and drivers are correctly installed:
   - `Chrome`: Install **Google Chrome** and ensure the version matches your `ChromeDriver`.
   - `Firefox`: Install **Mozilla Firefox**.
   - `Edge`: Install **Microsoft Edge`.

5. Ensure the `config.json` file is properly configured for your environment:
   ```json
   {
     "baseUrl": "https://www.saucedemo.com",
     "supportedBrowsers": ["chrome", "firefox", "edge"],
     "implicitWait": 10,
     "reportPath": "./Reports",
     "parallelExecution": true
   }
   ```

---

### **How to Execute Tests**

#### **Option 1: Using Visual Studio Test Explorer**
1. Open the project in Visual Studio.
2. Navigate to **Test > Test Explorer**.
3. Click **Run All** or select specific tests to execute.

#### **Option 2: Using CLI (`dotnet` commands)**
1. Open a terminal/command prompt in your project directory.
2. Execute all tests with:
   ```bash
   dotnet test
   ```

3. Run tests with a specific browser dynamically using NUnit parameters:
   ```bash
   dotnet test -- TestRunParameters.Parameter(name="browser", value="firefox")
   ```

---

### **Generated Reports**

After running the tests, an **HTML report** will be generated in the `Reports` folder. Open the `TestReport.html` file in any browser to view the detailed and interactive report.

---
