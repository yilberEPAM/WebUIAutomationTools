using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System.IO;

namespace CrossBrowser.Utilities
{
    public class ExtentManager
    {
        private static ExtentReports extent;

        public static ExtentReports GetReporter()
        {
            if (extent == null)
            {
                string reportPath = Path.Combine(BrowserConfig.Config["reportPath"].ToString(), "TestReport.html");
                var htmlReporter = new ExtentSparkReporter(reportPath);
                htmlReporter.Config.Theme = Theme.Dark;

                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }

            return extent;
        }
    }
}
