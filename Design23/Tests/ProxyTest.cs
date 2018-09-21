using System;
using Castle.DynamicProxy;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class ProxyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IGamePlayer playerA=new GamePlayerA();
            IGamePlayer proxyPlayer=new GamePlayerProxy(playerA);
    
            proxyPlayer.KillBoss();
            proxyPlayer.Upgrade();
            IGamePlayer playerB = new GamePlayerB();
            proxyPlayer = new GamePlayerProxy(playerB);
            proxyPlayer.KillBoss();
            proxyPlayer.Upgrade();
            proxyPlayer.Upgrade();

            //Debug Trace:
//A: 杀怪
//A:升级
//现总升级费用为50
//B: 杀怪
//B:升级
//现总升级费用为50
//B: 升级
//现总升级费用为100
        }
        [TestCategory("测试目录一")]
        [TestMethod]
        public void TestMethod3()
        {
            IGamePlayer player = DynamicProxy<GamePlayerA>.NewProxyInstance(new InvocationHandler());
            player.Upgrade();
            player.KillBoss();
            //Debug Trace:
            //A: 升级
            //    动态添加其他的操作
            //A: 杀怪
            //    动态添加其他的操作
        }
        [TestCategory("测试目录一")]
        [TestMethod]
        public void TestMethod4()
        {//未添加 virual
            IGamePlayer player = DynamicProxy<GamePlayerB>.NewProxyInstance(new InvocationHandler());
            player.Upgrade();
            player.KillBoss();
            //Debug Trace:
            //B: 升级
            //B:杀怪
        }
    }
}
