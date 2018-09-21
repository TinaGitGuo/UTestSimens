using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// 模板模式
    /// </summary>
    [TestClass]
    public class TempleteTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IHummer hummerH1=new HummerH1();
            hummerH1.Run();

            IHummer hummerH2 = new HummerH2();
            hummerH2.Run();
            //运行结果：
//            HummerH1 is Starting
//HummerH1 is EngineBoom
//HummerH1 is Alarmming
//HummerH1 is Stoping
//HummerH2 is Starting
//HummerH2 is EngineBoom
//HummerH2 is Alarmming
//HummerH2 is Stoping
        }
        [TestMethod]
        public void TestMethod2()
        {
            AbstractHummer hummerH3 = new HummerH3();
            hummerH3.Run();

            AbstractHummer hummerH4 = new HummerH4();
            hummerH4.Run();
            //运行结果：
//            HummerH3 is Starting
//HummerH3 is EngineBoom
//HummerH3 is Alarmming
//HummerH3 is Stoping
//HummerH4 is Starting
//HummerH4 is EngineBoom
//HummerH4 is Alarmming
//HummerH4 is Stoping
        }
    }
}
