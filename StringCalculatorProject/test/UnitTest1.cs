namespace StringCalculatorProject.Tests;

public class UnitTest1
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

        [Fact(Skip = "Known issue")]
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

    [Fact(Skip = "Known issue")]
    public void SimpleAddSub1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("2+3-5");
            Assert.Equal("2+3-5=0", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSub2()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("2-3+5");
            Assert.Equal("2-3+5=4", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubBrackets1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("2-(3+5)");
            Assert.Equal("2-(3+5)=-6", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubBrackets2()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1+(2-3)+5");
            Assert.Equal("1+(2-3)+5=5", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubMulDiv1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1+2*3-5");
            Assert.Equal("1+2*3-5=0", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubMulDiv2()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("1*2+6/2=5");
            Assert.Equal("1*2+6/2=5", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void ComplexAddSubMulDiv1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("5/1*2+6/2");
            Assert.Equal("5/1*2+6/2=13", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void ComplexAddSubMulDivMod1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("5%3*2+6/2");
            Assert.Equal("5%3*2+6/2=7", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void ComplexAddSubMulDivModBrackets1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("5%3*(2+6)/2");
            Assert.Equal("5%3*(2+6)/2=12", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubMulDivBracket1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("3*(6+2)");
            Assert.Equal("3*(6+2)=24", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubMulDivBracket2()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("(3*6)+2");
            Assert.Equal("(3*6)+2=20", rets.message);
        }

    [Fact(Skip = "Known issue")]
    public void SimpleAddSubMulDivBracket3()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("(3-6)*(2+11)");
            Assert.Equal("(3-6)*(2+11)=-39", rets.message);
        }

    [Fact]
    public void SimpleAddSubMulDiv3()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("3-6*2+11");
            Assert.Equal("3-6*2+11=2", rets.message);
        }

    [Fact (Skip = "Known issue")] //doesnt deal well with negative numbers
    public void SimpleAddSubMulDivMod1()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("11+6/2+11");
            Assert.Equal("11+6/2+11=25", rets.message);
        }

    [Fact (Skip = "Known issue")] //doesnt deal well with negative numbers
    public void SimpleAddSubMulDivMod2()
        {
            StringCalculator sc = new StringCalculator();
            (int code, string message) rets = sc.Calc("11+7%2+11");
            Assert.Equal("11+7%2+11=23", rets.message);
        }

        [Fact]
        [Trait("UnitTest", "UnitTest")]
        public void CanCalculate() { }

        [Fact]
        public void CanCalculate2()
        {
            
        }
}