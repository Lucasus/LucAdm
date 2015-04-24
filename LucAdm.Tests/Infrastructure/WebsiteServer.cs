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

            var configuration = ConfigurationManager.AppSettings.Get("Configuration");

            if(configuration == "Debug")
            {
                var projectFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LucAdm.Web\LucAdm.Web.csproj");
                var msbuildArguments = String.Format("{0} /p:DeployOnBuild=true /p:PublishProfile={1} /p:Configuration={2} /p:VisualStudioVersion=12.0",
                    projectFileName, configuration, configuration);

                var publishProcess = new Process
                {
                    StartInfo =
                    {
                        FileName = ConfigurationManager.AppSettings.Get("MSBuildPath"),
                        Arguments = msbuildArguments,
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

                var applicationPath = ConfigurationManager.AppSettings.Get("WwwRootPath");
                var port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));

                _process = new Process
                {
                    StartInfo =
                    {
                        FileName = ConfigurationManager.AppSettings.Get("IISExpressPath"),
                        Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, port)
                    }
                };
                _process.Start();
            }


            return this;
        }

        public void Stop()
        {
            var configuration = ConfigurationManager.AppSettings.Get("Configuration");

            if (configuration == "Debug")
            {
                if (_process.HasExited == false)
                {
                    _process.Kill();
                }
                _isStarted = false;
            }
        }
    }
}