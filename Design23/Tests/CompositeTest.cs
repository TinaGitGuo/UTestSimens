using System;
using System.Diagnostics;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// 组合模式
    /// </summary>
    [TestClass]
    public class CompositeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine($"公司人员信息 ： \n\t{CorpRoot.GetTreeInfo(CompositeCorpTree())}");
            //Debug Trace:
            //员工c 的公司关系信息 ： 

            //姓名：c 职位：开发人员 薪水：2000  的领导
            //    姓名：杨三乜斜 职位：开发一组组长 薪水：5000  的领导
            //    姓名：刘大瘸子 职位：研发部门经理 薪水：10000  的领导
            //    姓名：王大麻子 职位：总经理 薪水：100000  的领导

            //    公司人员信息 ： 

            //姓名：k 职位：CEO秘书 薪水：8000

            //姓名：刘大瘸子 职位：研发部门经理 薪水：10000

            //姓名：郑老六 职位：研发部副经理 薪水：20000

            //姓名：杨三乜斜 职位：开发一组组长 薪水：5000

            //姓名：a 职位：开发人员 薪水：2000

            //姓名：c 职位：开发人员 薪水：2000

            //姓名：吴大棒槌 职位：开发二组组长 薪水：6000

            //姓名：d 职位：开发人员 薪水：2000

            //姓名：e 职位：开发人员 薪水：2000

            //姓名：f 职位：开发人员 薪水：2000

            //姓名：g 职位：开发人员 薪水：2000

            //姓名：马二拐子 职位：销售部门经理 薪水：20000

            //姓名：h 职位：销售人员 薪水：5000

            //姓名：i 职位：销售人员 薪水：4000

            //姓名：赵三驼子 职位：财务部经理 薪水：30000

            //姓名：j 职位：财务人员 薪水：5000
        }
        //把整个树组装出来
        public CorpBranch CompositeCorpTree()
        {
            //首先产生总经理CEO
            CorpBranch root = new CorpBranch("王大麻子", "总经理", 100000);
            //把三个部门经理产生出来
            CorpBranch developDep = new CorpBranch("刘大瘸子", "研发部门经理", 10000);
            CorpBranch salesDep = new CorpBranch("马二拐子", "销售部门经理", 20000);
            CorpBranch financeDep = new CorpBranch("赵三驼子", "财务部经理", 30000);
            //再把三个小组长产生出来
            CorpBranch firstDevGroup = new CorpBranch("杨三乜斜", "开发一组组长", 5000);
            CorpBranch secondDevGroup = new CorpBranch("吴大棒槌", "开发二组组长", 6000);
            //把所有的小兵都产生出来
            CorpLeaf a = new CorpLeaf("a", "开发人员", 2000);
            CorpLeaf b = new CorpLeaf("b", "开发人员", 2000);
            CorpLeaf c = new CorpLeaf("c", "开发人员", 2000);
            CorpLeaf d = new CorpLeaf("d", "开发人员", 2000);
            CorpLeaf e = new CorpLeaf("e", "开发人员", 2000);
            CorpLeaf f = new CorpLeaf("f", "开发人员", 2000);
            CorpLeaf g = new CorpLeaf("g", "开发人员", 2000);
            CorpLeaf h = new CorpLeaf("h", "销售人员", 5000);
            CorpLeaf i = new CorpLeaf("i", "销售人员", 4000);
            CorpLeaf j = new CorpLeaf("j", "财务人员", 5000);
            CorpLeaf k = new CorpLeaf("k", "CEO秘书", 8000);
            CorpLeaf zhengLaoLiu = new CorpLeaf("郑老六", "研发部副经理", 20000);
            //开始组装
            //CEO下有三个部门经理和一个秘书
            root.Add(k);
            root.Add(developDep);
            root.Add(salesDep);
            root.Add(financeDep);
            //研发部经理
            developDep.Add(zhengLaoLiu);
            developDep.Add(firstDevGroup);
            developDep.Add(secondDevGroup);
            //看看两个开发小组下有什么
            firstDevGroup.Add(a);
            firstDevGroup.Add(b);
            firstDevGroup.Add(c);
            secondDevGroup.Add(d);
            secondDevGroup.Add(e);
            secondDevGroup.Add(f);
            secondDevGroup.Add(g);
            
            //再看销售部下的人员情况
            salesDep.Add(h);
            salesDep.Add(i);
            //最后一个财务
            financeDep.Add(j);

            firstDevGroup.Remove(b);
            firstDevGroup.Remove(k);//不报错

            Debug.WriteLine($"员工c 的公司关系信息 ： \n\t{CorpRoot.GetParentTreeInfo(c)} ");
            return root;
        }
    }
}
