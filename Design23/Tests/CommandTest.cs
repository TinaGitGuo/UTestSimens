using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// 命令模式
    /// </summary>
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Invoker o=new Invoker();
            Command command=new AddRequirementCommand();
            o.SetCommand(command);
            o.Action();
            //Debug Trace:
            //Requirement Find
            //Code Find
            //Requirement Add
            //Code delete
            //Requirement Plan
            
            o.SetCommand(new CancelDeletePageCommand());
            o.Action();
            //根据日志，取消操作
        }
    }
}
