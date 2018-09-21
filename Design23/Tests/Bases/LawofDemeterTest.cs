using System;
using System.Collections.Generic;
using Design23.Designs.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests.Bases
{
    /// <summary>
    /// 迪米特法则
    /// </summary>
    [TestClass]
    public class LawofDemeterTest
    {
        [Description("老师类 只需要一个朋友也就是班长类，将命令告诉班长，调用班长的数数的功能： 班长类去处理内部的细节")]
        [TestMethod]
        public void TestMethod1()
        {
            Teacher teacher=new Teacher();
            List<string> girls = new List<string> {"女生A", "女生B"};
            GroupLeader groupLeader=new GroupLeader(girls);
            teacher.Commond(groupLeader);
            //共有2个女生
        }
    }
}
