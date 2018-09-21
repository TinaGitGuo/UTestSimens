using System;
using Design23.Designs.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests.Bases
{
    /// <summary>
    /// 里氏转换 Liskov Substitution Principle， LSP
    /// </summary>
    [TestClass]
    public class LiskovSubstitutionPrincipleTest
    {
        [TestMethod]
        [Description("里氏转换LSP")]
        public void TestMethod1()
        {
            AbstractGun handgun = new HandGun();
            Soldier soldier = new Soldier();
            soldier.SetGun(handgun);
            soldier.KillEnemy();

            AbstractGun augRifleGun = new AUGRifleGun();
            soldier.SetGun(augRifleGun);
            soldier.KillEnemy();
            //Output:
//            士兵开始杀敌人
//手枪射击
//士兵开始杀敌人
//AUG 狙击枪 射击
        }
        [TestMethod]
        [Description("正常写法")]
        public void TestMethod2()
        {
            Snipper snipper = new Snipper();
            AUGRifleGun augrifleGun = new AUGRifleGun();
            snipper.KillEnemy(augrifleGun);
            //Output:
//            通过望远镜查看敌人
//AUG 狙击枪 射击
        }
        [TestMethod]
        [Description("非里氏转换LSP")]
        public void TestMethod3()
        {
            Snipper snipper = new Snipper();
            RifleGun rifleGun = new RifleGun();
            snipper.KillEnemy((AUGRifleGun)rifleGun);
            //报错Error
        }
        [TestMethod]
        [Description("非里氏转换LSP")]
        public void TestMethod5()
        {
            Snipper snipper = new Snipper();
            RifleGun augrifleGun = new AUGRifleGun();
            snipper.KillEnemy((AUGRifleGun)augrifleGun);
            //Output:
//            通过望远镜查看敌人
//AUG 狙击枪 射击
        }
        [TestMethod]
        [Description("里氏转换LSP")]
        public void TestMethod4()
        {
            Father father = new Father();
            father.Walking(1,2);
            //父类出现的地方，子类就可以出现
            Son son=new Son();
            son.Walking(1,2);

            son.Walking("走路");
            Father son2 = new Son();
            son2.Walking(1, 2);
            //运行结果
            //a + b = 3
            //a + b = 3
            //I 'am 走路
            //a + b = 3
        }
    }
}
