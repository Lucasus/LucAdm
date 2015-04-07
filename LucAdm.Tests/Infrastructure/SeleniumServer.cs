using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.Tests
{
    public class SeleniumServer
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
    }
}
