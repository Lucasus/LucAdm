using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LucAdm.Tests
{
    public sealed class WebsiteServer : IDisposable
    {
        private bool _isStarted;
        private Process _process;

        public void Dispose()
        {
            if (_process != null)
            {
                _process.Dispose();
            }
        }

        public WebsiteServer Start()
        {
            //TODO: Remove everything from website path first

            // Publish newest website version
            var projectFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LucAdm.Web\LucAdm.Web.csproj");
            var publishProcess = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Program Files (x86)\MSBuild\12.0\Bin\amd64\MSBuild.exe",
                    Arguments = projectFileName + " /p:DeployOnBuild=true /p:PublishProfile=Debug /p:VisualStudioVersion=12.0",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            publishProcess.Start();

            var output = publishProcess.StandardOutput.ReadToEnd();
            publishProcess.WaitForExit();
            if (!output.Contains("Build succeeded"))
            {
                throw new Exception("Build exception: " + output);
            }

            // Start IIS Express
            if (_isStarted)
            {
                return this;
            }

            _isStarted = true;

            var applicationPath = @"C:\wwwroot\LucAdm";
            var port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));

            _process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Program Files\IIS Express\iisexpress.exe",
                    Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, port)
                }
            };
            _process.Start();
            return this;
        }

        public void Stop()
        {
            if (_process.HasExited == false)
            {
                _process.Kill();
            }
            _isStarted = false;
        }
    }
}