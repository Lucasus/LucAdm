﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LucAdm.Tests
{
    public sealed class WebsiteServer : IDisposable
    {
        private Process process;
        private bool isStarted = false;

        public WebsiteServer Start()
        {
            // Publish newest website version
            var publishProcess = new Process();
            var projectFileName =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LucAdm.Web\LucAdm.Web.csproj");
            //             publishProcess.StartInfo.FileName = Environment.GetEnvironmentVariable("MSBUILD_PATH");
            publishProcess.StartInfo.FileName =  @"C:\Program Files (x86)\MSBuild\12.0\Bin\amd64\MSBuild.exe";
            publishProcess.StartInfo.Arguments = projectFileName + " /p:DeployOnBuild=true /p:PublishProfile=LocalTest /p:VisualStudioVersion=12.0";
            publishProcess.Start();
            publishProcess.WaitForExit();

            // Start IIS Express
            if (isStarted)
            {
                return this;
            }

            isStarted = true;

            var applicationPath = @"C:\wwwroot\LucAdm";
            var port = Int32.Parse(ConfigurationManager.AppSettings.Get("Port"));
 
            process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            process.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, port);
            process.Start();
            return this;
        }

        public void Stop()
        {
            if (process.HasExited == false)
            {
                process.Kill();
            }
            isStarted = false;
        }

        private string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }

        public void Dispose()
        {
            if(process != null)
            {
                process.Dispose();
            }
        }
    }
}