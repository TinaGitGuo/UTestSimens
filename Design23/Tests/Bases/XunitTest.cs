using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
 using Assert= Xunit.Assert;
namespace Design23.Tests.Bases
{
    public class XunitTest
    {
        [Fact]
        public void PassingTest()
        {
             Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
              Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
             Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
    [Collection("#1")]
    public class TestClass1
    {
        [Fact]
        public void TestCollection1()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("#1")]
    public class TestClass2
    {
        [Fact]
        public void TestCollection2()
        {
            Thread.Sleep(5000);
        }
    }
}
