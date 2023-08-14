using Xunit;

namespace Calculator
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringShouldReturnErrorCodeMinusOne()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("");
            Assert.True(rets.code == -1);
        }

        [Fact]
        [Trait("UnitTest", "UnitTest")]
        public void CanCalculate() { }

        [Fact]
        public void CanCalculate2()
        {

        }
    }
}

