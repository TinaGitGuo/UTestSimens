using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class ChainOfResponsibilityTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AbstractHandler father = new Father();
            AbstractHandler husband = new Husband();
            AbstractHandler son = new Son();
            father.SetNext(husband);
            husband.SetNext(son);

            Random random=new Random();
            for (int i = 0; i < 160; i++)
            {
                IWomen women = new Women((WomenLevelEnum) random.Next(0,3), "我要出去玩");
                father.HandleMessage(women);
            }
//            --Alone 没有地方请示，按不同意处理--
//Father 同意  Daughter 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//Father 同意  Daughter 我要出去玩 的请求
//Husband 同意 Wife 我要出去玩 的请求
//Father 同意  Daughter 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//--Alone 没有地方请示，按不同意处理--
//Husband 同意  Wife 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//--Alone 没有地方请示，按不同意处理--
//Father 同意  Daughter 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//--Alone 没有地方请示，按不同意处理--
//-- Alone 没有地方请示，按不同意处理--
//-- Alone 没有地方请示，按不同意处理--
//-- Alone 没有地方请示，按不同意处理--
//Husband 同意  Wife 我要出去玩 的请求
//Husband 同意 Wife 我要出去玩 的请求
//Husband 同意  Wife 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//Husband 同意  Wife 我要出去玩 的请求
//-- Alone 没有地方请示，按不同意处理--
//-- Alone 没有地方请示，按不同意处理--

        }
        [TestMethod]
        public void TestMethod2()
        {
            AbstractHandler father = new Father();
            AbstractHandler husband = new Husband();
            AbstractHandler son = new Son();
            son.SetNext(father);

            Random random = new Random();
            for (int i = 0; i < 160; i++)
            {
                IWomen women = new Women((WomenLevelEnum)random.Next(0, 3), "我要出去玩");
                son.HandleMessage(women);
            }
//            Debug Trace:
//--Wife 没有地方请示，按不同意处理--
//Father 同意  Daughter 我要出去玩 的请求
//Father 同意 Daughter 我要出去玩 的请求
//--Alone 没有地方请示，按不同意处理--
//-- Wife 没有地方请示，按不同意处理--
//-- Alone 没有地方请示，按不同意处理--
        }
    }
}
