using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Simens3iTest
{
    [TestClass]
    public class UTRegex
    {
        [Description("字符串必须包含　数字　和　字母")]
        [TestMethod]
        public void TestMethod1()
        {
            //string input = "Password@a";
            string input = "1r";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]";                              
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void TestMethod11()
        {
            //string input = "Password@a";
            string input = "11111";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(!b);
        }
        [TestMethod]
        public void TestMethod111()
        {
            //string input = "Password@a";
            string input = "abdfewwe";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(!b);
        }
        [TestMethod]
        public void TestMethod1111()
        {
            //string input = "Password@a";
            string input = "abdfewwe111....";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void TestMethod2()
        {
            bool c= Regex.IsMatch("ss****ss", @"^[^<?\x22]+$", RegexOptions.IgnoreCase); ;
            Assert.IsTrue(c);//正确
            //string input = "eesss.*";
            //string pattern = @"^[^<?\x22]+$";     
            //bool b = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
            //Assert.IsFalse(b);
        }
        [TestMethod]
        public void TestMethod22()
        {
            string input = "wwewe<wew";
            string pattern = @"[^<?\\x22]+";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void TestMethod222()
        {
            string input = "wwewewew";
            string pattern = @"^[^<?\x22]+$";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(!b);
        }
        [TestMethod]
        public void TestMethod222s()
        {
            string input = "12345a1";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]"; 
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void TestMethod222s33()
        {
            string input = "a12345a1a";
            string pattern = @"[A-Za-z].*[0-9]|[0-9].*[A-Za-z]";
            bool b = Regex.IsMatch(input, pattern);
            Assert.IsTrue(b);
        }
    }
}
