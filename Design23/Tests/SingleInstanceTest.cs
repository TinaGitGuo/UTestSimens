using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class SingleInstanceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            SingleInstance p= SingleInstance.GetInstance();
            Assert.IsNotNull(p);
            SingleInstance p1 = SingleInstance.GetInstance();
            Assert.IsNotNull(p1);
            SingleInstance p2 = SingleInstance.GetInstance();
            Assert.IsNotNull(p2);
            SingleInstance p3 = SingleInstance.GetInstance();
            Assert.IsNotNull(p3);
            //结果
            //新的实例
            //原来的实例
            //原来的实例
            //原来的实例
        }
    }
}
