using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Design23.Designs
{
    #region 代理模式 Proxy Pattern
    public interface IGamePlayer
    {
        void KillBoss();
        void Upgrade();
    }
    public class GamePlayerA : IGamePlayer
    {
        public virtual void KillBoss()
        {
            Debug.WriteLine("A:杀怪");
        }

        public virtual void Upgrade()
        {
            Debug.WriteLine("A:升级");
        }
    }
    public class GamePlayerB : IGamePlayer
    {
        public void KillBoss()
        {
            Debug.WriteLine("B:杀怪");
        }

        public void Upgrade()
        {
            Debug.WriteLine("B:升级");
        }
    }

    public interface IProxy
    {
        void Count();
    }
    public class GamePlayerProxy : IGamePlayer, IProxy
    {
        private readonly IGamePlayer _objGamePlayer;
        public decimal Money { get; set; } = 0;
        public GamePlayerProxy(IGamePlayer objGamePlayer)
        {
            this._objGamePlayer = objGamePlayer;
        }
        public void KillBoss()
        {
            this._objGamePlayer.KillBoss();
        }
        public void Upgrade()
        {
            this._objGamePlayer.Upgrade();
            this.Count();
            Debug.WriteLine("现总升级费用为" + Money);
        }
        public void Count()
        {
            Money += 50;
        }
    }
    #endregion

    #region 动态代理模式
    //public class ProxyGenerator
    //{
    //    public ProxyGenerator();
    //    public ProxyGenerator(IProxyBuilder builder);
    //    public IProxyBuilder ProxyBuilder { get; }
    //    public T CreateClassProxy<T>(params IInterceptor[] interceptors);
    //}
    public class InvocationHandler:  IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            Print();
        }
        public void Print()
        {
            Debug.WriteLine("动态添加其他的操作");
        }
    }
    public class DynamicProxy<T>  where T : class
    {
        public static T NewProxyInstance(InvocationHandler invocationHandler)
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            return  proxyGenerator.CreateClassProxy<T>(invocationHandler);  
        }  
    }
    #endregion
}
