using System;
using Xunit;

namespace Tests
{
    public class Test
    {

        [Fact]
        public void Pass() {
            Assert.True(true);
        }   

        [Fact(Skip = "Ignore failing test for build")]
        public void Fail() {
            Assert.False(false);
        }
    }
}