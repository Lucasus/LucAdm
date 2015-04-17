using System;
using System.Diagnostics;

namespace LucAdm.Tests
{
    public sealed class SeleniumServer : IDisposable
    {
        private Process process;
        private bool isStarted = false;

        public SeleniumServer Start()
        {
            if (isStarted)
            {
                return this;
            }

            isStarted = true;

            process = new Process();
            process.StartInfo.FileName = "java";
            process.StartInfo.Arguments = JavaArguments;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            return this;
        }

        public void Stop()
        {
            process.Kill();
            isStarted = false;
        }

        private string JavaArguments
        {
            get
            {
                // TODO: we need to take this path from settings
                return @"-jar C:\Core\selenium-server-standalone-2.45.0.jar";
            }
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
