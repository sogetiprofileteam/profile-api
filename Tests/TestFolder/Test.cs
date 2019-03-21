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

        [Fact]
        public void Fail() {
            Assert.False(true);
        }
    }
}