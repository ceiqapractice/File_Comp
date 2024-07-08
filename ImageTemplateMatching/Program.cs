using System;
using System.IO;
using OpenCvSharp;
using Microsoft.Playwright;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string scriptDir = Directory.GetCurrentDirectory();
        string htmlFilePath = Path.Combine(scriptDir, "index.html"); // Adjust this path to your index.html
        string screenshotPath = "screenshot.png";
        string imagePath = "partial_image.png"; // Adjust this path to the image you want to find

        await CaptureScreenshotOfLocalHtml(htmlFilePath, screenshotPath);
        FindAndDisplayImageInScreenshot(screenshotPath, imagePath);
    }

    static async Task CaptureScreenshotOfLocalHtml(string htmlFilePath, string screenshotPath)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();

        // Load the local HTML file
        await page.GotoAsync($"file://{htmlFilePath}");

        // Capture screenshot
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

        await browser.CloseAsync();
    }

    static void FindAndDisplayImageInScreenshot(string screenshotPath, string imagePath)
    {
        var screenshot = Cv2.ImRead(screenshotPath, ImreadModes.Color);
        var image = Cv2.ImRead(imagePath, ImreadModes.Color);

        if (screenshot.Empty())
        {
            Console.WriteLine($"Error: Unable to read screenshot from {screenshotPath}");
            return;
        }

        if (image.Empty())
        {
            Console.WriteLine($"Error: Unable to read image template from {imagePath}");
            return;
        }

        // Perform template matching
        var result = new Mat();
        Cv2.MatchTemplate(screenshot, image, result, TemplateMatchModes.CCoeffNormed);
        double minVal, maxVal;
        Point minLoc, maxLoc;
        Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);
        
        if (maxVal >= 0.8) // Adjust threshold as needed
        {
            var topLeft = maxLoc;
            var bottomRight = new Point(topLeft.X + image.Width, topLeft.Y + image.Height);
            Cv2.Rectangle(screenshot, topLeft, bottomRight, Scalar.Green, 4);
        }

        // Display result using OpenCvSharp
        Cv2.ImShow("Screenshot with partial image highlighted", screenshot);
        Cv2.ImShow("Partial image", image);
        Cv2.WaitKey(0);
    }
}
