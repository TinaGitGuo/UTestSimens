using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Designs
{
    #region 工厂模式
    public interface IFactory<T> where T : class
    {
        T CreateObject(Type t);
    }
    public class Factory<T> : IFactory<T> where T : class
    {
        public T CreateObject(Type type)
        {
            return (T)type.Assembly.CreateInstance(type.FullName ?? throw new InvalidOperationException());
        }
    }
    #endregion

    #region 简单工厂（静态工厂）
    public class StaticFactory<T> where T : class
    {
        private static readonly IFactory<T> Factory = new Factory<T>();
        public static T CreateObject(Type type)
        {
            return Factory.CreateObject(type);
        }
    }
    #endregion
    #region 工厂模式-人
    public abstract class AbstractPersonFactory<T> where T : class
    {
        public IFactory<T> Factory = new Factory<T>();
        public abstract T CreatePerson();
    }
    public class PersonFactory<T> : AbstractPersonFactory<T> where T : class, IPerson
    {
        [Description("人")]
        public override T CreatePerson()
        {
            return Factory.CreateObject(typeof(Person));
        }
    }
    public class Person : IPerson
    {
        public void Eat()
        {
            Debug.WriteLine("Person： is eatting");
        }
        public void Move()
        {
            Debug.WriteLine("Person is Moving");
        }
    }
    #endregion

    #region 多个工厂模式

    public class WhitePersonFactory<T> : AbstractPersonFactory<T> where T : class, IPerson
    {
        [Description("白人")]
        public override T CreatePerson()
        {
            return Factory.CreateObject(typeof(WhitePerson));
        }
    }
    public class BlackPersonFactory<T> : AbstractPersonFactory<T> where T : class, IPerson
    {
        [Description("黑人")]
        public override T CreatePerson()
        {
            return Factory.CreateObject(typeof(BlackPerson));
        }
    }
    #endregion
    public class WhitePerson : IPerson
    {
        public void Eat()
        {
            Debug.WriteLine("White Person is eatting");
        }
        public void Move()
        {
            Debug.WriteLine("White Person is Moving");
        }
    }
    public class BlackPerson : IPerson
    {
        public void Eat()
        {
            Debug.WriteLine("Black Person is eatting");
        }

        public void Move()
        {
            Debug.WriteLine("Black Person is Moving");
        }
    }
    public interface IPerson
    {
        void Eat();
        void Move();
    }
}
