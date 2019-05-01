using System;
using Xunit;

namespace Tests
{
    public class XunitTest
    {

        [Fact]
        public void XUnitPass() {
            Assert.True(true);
        }   
    }
}