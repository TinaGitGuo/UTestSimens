using System;
using System.Collections;
using System.Diagnostics;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IProjectEnumerable project = new ProjectEnumerable();
            for (int i = 0; i < 3; i++)
            {
                project.Add("name" +i, 2, 3);
            }
            IEnumerator projectIterator= project.GetEnumerator() ;
            while (projectIterator.MoveNext())
            {
                IProjectEnumerable p =(IProjectEnumerable) projectIterator.Current;
                if (p != null) Debug.WriteLine($"人员信息： \n {p.GetProjectInfo()}");
            }
            //Debug Trace:
            //人员信息： 
            //项目名称是：name0 项目人数: 2  项目费用：3
            //人员信息： 
            //项目名称是：name1 项目人数: 2  项目费用：3
            //人员信息： 
            //项目名称是：name2 项目人数: 2  项目费用：3
        }
        [TestMethod]
        public void TestMethod2()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new ProjectEnumerable("name" + i, 2, 3));
            }
            foreach (ProjectEnumerable p in list)
            {
                Debug.WriteLine($"人员信息： \n {p.GetProjectInfo()}");
            }
            //Debug Trace:
            //人员信息： 
            //项目名称是：name0 项目人数: 2  项目费用：3
            //人员信息： 
            //项目名称是：name1 项目人数: 2  项目费用：3
            //人员信息： 
            //项目名称是：name2 项目人数: 2  项目费用：3
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyIteratorYield o=new MyIteratorYield();
            foreach (var a in o)
            {
                Debug.WriteLine($"值为 ： {a}");
            }
            //Debug Trace:
            //值为 ： 2
            //值为 ： 56
            //值为 ： 34
        }
    }
}
