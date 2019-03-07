using System;
using Xunit;
using CalciCi;
using Shouldly;

namespace UnitTests
{
    public class SimpleCalciTests
    {
        [Fact]
        public void SimpleCalci_Test()
        {
            var cal = new SimpleCalci();
            var res = cal.Sum(1,2);
            res.ShouldBe(3);
        }
    }
}
