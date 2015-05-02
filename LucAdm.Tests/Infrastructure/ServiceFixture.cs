using System;
using System.Data.Entity.Migrations;

namespace LucAdm.Tests
{
    public sealed class ServiceFixture : IDisposable
    {
        public ServiceFixture()
        {
            AutoMapperConfig.Register();
        }

        public void Dispose()
        {
        }
    }
}