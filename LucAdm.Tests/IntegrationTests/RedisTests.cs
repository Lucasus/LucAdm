using StackExchange.Redis;
using Xunit;
using FluentAssertions;

namespace LucAdm.Tests
{
    public class RedisTests
    {
        [NamedFact]
        [Trait("Category", "Integration-Experimental")]
        public void Should_Correctly_Connect_To_Redis()
        {
            var redis = ConnectionMultiplexer.Connect("192.168.1.193:6379");

            redis.IsConnected.Should().BeTrue();
        }
}
    }