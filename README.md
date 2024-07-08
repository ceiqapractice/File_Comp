# Image Template Matching using Playwright and OpenCvSharp

This project demonstrates how to automate the capture of a screenshot from a local HTML file using Playwright and perform image template matching using OpenCvSharp in a .NET environment.

## Overview

The project consists of two main functionalities:

1. **Capture Screenshot of Local HTML File:**
   - Uses Playwright to launch a Chromium browser, load a local HTML file, and capture a screenshot.

2. **Image Template Matching:**
   - Uses OpenCvSharp to perform template matching on the captured screenshot against a specified partial image template.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [PlaywrightSharp](https://github.com/microsoft/playwright-sharp) NuGet package
- [OpenCvSharp4](https://github.com/shimat/opencvsharp) NuGet package

## Installation and Setup

1. **Clone the Repository:**
     ```bash
      https://github.com/ceiqapractice/File_Comp.git
      cd ImageTemplateMatching
2. **Restore Dependencies:**
     ```bash
      dotnet restore
3. **Install Playwright:**
     ```bash
      playwright install
4. **Build and Run:**
     ```bash
      dotnet build
      dotnet run
5. **Output:**

![image](https://github.com/ceiqapractice/File_Comp/assets/110914539/34dd3246-d854-40ca-b06a-714a746a727b)

5. **Explanation:**

Main Method: The entry point of the program. It sets up paths for the HTML file, screenshot, and image template, then calls the functions to capture the screenshot and perform image template matching.

CaptureScreenshotOfLocalHtml Method: Uses Playwright to launch a headless Chromium browser, navigate to a local HTML file (index.html), and capture a screenshot (screenshot.png).

FindAndDisplayImageInScreenshot Method: Uses OpenCvSharp to read the screenshot and image template, perform template matching, highlight the matched area (if any), and display the images using OpenCV functions.
        
## USAGE

1. Replace index.html with your own HTML file to test different scenarios.
2. Replace partial_image.png with the image you want to match within the screenshot.
