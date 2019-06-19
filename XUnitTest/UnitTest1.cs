using System;
using Xunit;
using UnitTestApp;
using Moq;
using System.Linq.Expressions;

namespace XUnitTest
{
    public class TestCalc
    {
        Calc c;
        public TestCalc(Calc calc)
        {
            c = calc;
        }
        public void TestSum()
        {
            c.Sum(1, 2);
        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calc = new Calc();
            var v = calc.VersionNumber();
            Assert.Equal(0, v);
        }

        [Theory]
        [InlineData(1, 2)]
        public void TestSum1(int a, int b)
        {
            var calc = new Calc();
            var v = calc.Sum(a, b);
            Assert.Equal(3, v);
        }

        [Theory]
        [InlineData(1, 3)]
        public void TestSum2(int a, int b)
        {
            var calc = new Calc();
            var v = calc.Sum(a, b);
            Assert.Equal(4, v);
        }

        [Fact]
        public void TestMock1()
        {
            var mock = new Mock<Calc>();
            Expression<Func<Calc, int>> call = obj => obj.Sum(It.IsAny<int>(), It.IsAny<int>());

            mock.Setup(call)
                .Returns(() => 
                    {
                        Console.WriteLine("Test is called");
                        return 1;
                    })
                .Verifiable();
            var testCalc = new TestCalc(mock.Object);
            testCalc.TestSum();
            mock.Verify(call, Times.Once);
        }
        [Fact]
        public void TestMock2()
        {
            var mock = new Mock<Calc>();
            Expression<Func<Calc, int>> call = obj => obj.Sum(It.IsAny<int>(), It.IsAny<int>());

            mock.Setup(call)
                .Returns(() =>
                {
                    Console.WriteLine("Test is called");
                    return 1;
                })
                .Verifiable();

            mock.Object.Sum(1,2);

            mock.Verify(call, Times.Once);
        }
    }
}
