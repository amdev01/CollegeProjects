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
            Assert.Equal(-1, rets.code);
        }

        [Fact]  
        public void NullStringShouldReturnErrorCodeMinusOne()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc(null);
            Assert.Equal(-1, rets.code);
        }

        [Fact]  
        public void LargeStringShouldReturnErrorCodeMinusOne()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1+2+3+4+5+6+7+8+9+10+11+12");
            Assert.Equal(-1, rets.code);
        }

        [Fact]  
        public void InputHelpShouldReturnCodeOne()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("help");
            Assert.Equal(1, rets.code);
        }

        [Fact]  
        public void ValidInputNoEquationShouldReturnErrorCodeMinusOne()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("222");
            Assert.Equal(-1, rets.code);
        }

        [Fact]  
        public void InputOnlyLettersShouldReturnErrorCodeMinusTwo()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("abcd");
            Assert.Equal(-2, rets.code);
        }

        [Fact]  
        public void InputLettersAndOperandsShouldReturnErrorCodeMinusTwo()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("ad+cd");
            Assert.Equal(-2, rets.code);
        }


        [Fact]  
        public void InputLettersOperandsAndNumbersShouldReturnErrorCodeMinusTwo()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1+a+2+d");
            Assert.Equal(-2, rets.code);
        }

        [Fact]  
        public void InputHelpBetweenOperandsAndNumbersShouldReturnErrorCodeMinusTwo()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1+2+help+3");
            Assert.Equal(-2, rets.code);
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

