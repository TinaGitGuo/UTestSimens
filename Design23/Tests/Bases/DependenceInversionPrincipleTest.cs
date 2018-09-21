using System;
using Design23.Designs.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests.Bases
{
    /// <summary>
    ///依赖倒置DIP， Dependence Inversion Principle
    /// </summary>
    [TestClass]
    public class DependenceInversionPrincipleTest
    {
        [TestMethod]
        [Description("依赖倒置DIP：接口注入")]
        public void TestMethod1()
        {
            IDriver driver=new Driver();
            ICar acar=new ACar();
            driver.ToDrive(acar);

            ICar bcar = new BCar();
            driver.ToDrive(bcar);
            //共5行
        }
        [TestMethod]
        [Description("依赖倒置DIP：构造函数注入")]
        public void TestMethod2()
        {
            ICar acar = new ACar();
            IDriver2 driver = new Driver2(acar);
            driver.ToDrive();

            ICar bcar = new BCar();
            IDriver2 driver2 = new Driver2(bcar);
            driver2.ToDrive();
            //共6行代码
        }
        [TestMethod]
        [Description("依赖倒置DIP：Setter注入")]
        public void TestMethod3()
        {
            ICar acar = new ACar();
            ICar bcar = new ACar();
            IDriver3 driver = new Driver3();

            driver.SetCar(acar);
            driver.ToDrive();

            driver.SetCar(bcar);
            driver.ToDrive();
            //共7行代码
        }
    }
}
