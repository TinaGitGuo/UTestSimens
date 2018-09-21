using System;
using Design23.Designs.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests.Bases
{
    /// <summary>
    /// 接口隔离原则
    /// </summary>
    [TestClass]
    public class InterfaceSegregationPrincipleTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPettyAGirl pettyA=new PettyAGirl("美女1号");
            ISearcher searcherA=new SearcherA(pettyA);
            searcherA.Show();

            IPettyBGirl pettyB = new PettyBGirl("美女2号");
            ISearcher searcherB = new SearcherB(pettyB);
            searcherB.Show();
//            ---信息如下-- -
//A类型美女美女1号：身材好
//A类型美女美女1号：脸蛋好
//A类型美女美女1号：气质好
//-- - 信息如下-- -
//B类型美女美女2号：气质特别好
        }
    }
}
