### Example Project: Automating Google Search with Appium and C#

#### Prerequisites
1. Install Visual Studio (Any edition supporting C#).
2. Install Appium Desktop or set up an Appium server.
3. Have an Android Emulator or a configured Android device.
4. Install the required NuGet Packages:
   - Selenium.WebDriver
   - Appium.WebDriver

#### Project Structure
Your project can have the following structure:
```
/AppiumCSharpExample
    /Drivers
        DriverSetup.cs
    GoogleSearchTest.cs
```

#### How to Set Up the Project in Visual Studio
1. Create a new project in Visual Studio using the "Console" template for C#.
2. Add the folders and files as shown in the structure.
3. Install the necessary NuGet packages:
   - Selenium.WebDriver
   - Appium.WebDriver
4. Copy and paste the code above into the corresponding files.
5. Ensure you have an Android device or emulator with Chrome installed and debugging enabled.
6. Launch the Appium server.

#### How to Run the Test
1. Start the Appium server.
2. Connect your Android device or start the emulator.
3. Run the application from Visual Studio (`GoogleSearchTest`).
4. Watch as the test opens Google, performs a search, and displays the first result in the console.

---