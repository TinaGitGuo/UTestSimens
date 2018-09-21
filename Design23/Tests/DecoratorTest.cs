using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// 装饰模式
    /// </summary>
    [TestClass]
    public class DecoratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ISchoolReport schoolReport = new OringalSchoolReport();
            schoolReport=new HighScoreDecorator(schoolReport);
            schoolReport=new SortDecorator(schoolReport);
            schoolReport.Report();
            schoolReport.Sign("老爸");
            //Debug Trace:
            //您的儿子的分数为65分
            //家长签名为 ： 老爸
        }
        [TestMethod]
        public void TestMethod2()
        {
            AbstractSchoolReport schoolReport = new OringalSchoolReport2();
            schoolReport = new HighScoreDecorator2(schoolReport);
            schoolReport = new SortDecorator2(schoolReport);
            schoolReport.Report();
            schoolReport.Sign("老爸");
//            Debug Trace:
//最高分
//您的儿子的分数为65分
//排名
//家长签名为 ： 老爸
        }
    }
}
