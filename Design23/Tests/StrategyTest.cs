using System;
using System.Diagnostics;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StrategyContext strategyContext=new StrategyContext(new BackDoor());
            strategyContext.Operate();
            strategyContext = new StrategyContext(new BlockEnemy());
            strategyContext.Operate();
            strategyContext = new StrategyContext(new GivenGreenLight());
            strategyContext.Operate();

//            Debug Trace:
//走后门
//断后
//开路灯
        }
        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine($"值为：  { Calculator.Add().Exec(1, 2)}");
            Debug.WriteLine($"值为：  { Calculator.Sub().Exec(1, 2)}");
            //Debug Trace:
            //值为：  3
            //值为：  -1
        }
    }
}
