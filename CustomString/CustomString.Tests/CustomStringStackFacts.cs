using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomString.Tests
{
    public class CustomStringStackFacts
    {
        [Fact]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>("capacity", () => new CustomStringStack(-2));
        }

    }
}
