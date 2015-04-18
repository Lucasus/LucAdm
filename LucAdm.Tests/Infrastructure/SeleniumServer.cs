using System;
using System.Diagnostics;

namespace LucAdm.Tests
{
    public sealed class SeleniumServer : IDisposable
    {
        private bool _isStarted;
        private Process _process;

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
            if (_process != null)
            {
                _process.Dispose();
            }
        }

        public SeleniumServer Start()
        {
            if (_isStarted)
            {
                return this;
            }

            _isStarted = true;

            _process = new Process
            {
                StartInfo =
                {
                    FileName = "java",
                    Arguments = JavaArguments,
                    CreateNoWindow = true
                }
            };
            _process.Start();
            return this;
        }

        public void Stop()
        {
            _process.Kill();
            _isStarted = false;
        }
    }
}