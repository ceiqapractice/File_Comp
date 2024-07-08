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
Usage
## USAGE

1. Replace index.html with your own HTML file to test different scenarios.
2. Replace partial_image.png with the image you want to match within the screenshot.
