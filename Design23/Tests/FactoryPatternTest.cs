using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class FactoryPatternTest
    {
        private IPerson _blackPerson;
        private IPerson _whitePerson;
        private IPerson _person;
        [Description("工厂模式")]
        [TestMethod]
        public void TestMethod1()
        {
            IFactory<IPerson> a = new Factory<IPerson>();
            _blackPerson = a.CreateObject(typeof(BlackPerson));
            _whitePerson = a.CreateObject(typeof(WhitePerson));

            _blackPerson.Move();
            _whitePerson.Move();
        }
        [Description("简单（静态）工厂模式")]
        [TestMethod]
        public void TestMethod3()
        {
            _blackPerson = StaticFactory<IPerson>.CreateObject(typeof(BlackPerson));
            _whitePerson = StaticFactory<IPerson>.CreateObject(typeof(BlackPerson));

            _blackPerson.Move();
            _whitePerson.Move();
        }
        [Description("人 -工厂模式")]
        [TestMethod]
        public void TestMethod4()
        {
            AbstractPersonFactory<IPerson> a = new PersonFactory<IPerson>();
            _person = a.CreatePerson();

            _person.Move();
            _person.Move();
        }
        [Description("人- 白人/黑人： 多个工厂模式")]
        [TestMethod]
        public void TestMethod2()
        {
            AbstractPersonFactory<IPerson> a = new BlackPersonFactory<IPerson>();
            AbstractPersonFactory<IPerson> b = new WhitePersonFactory<IPerson>();

            _blackPerson = a.CreatePerson();
            _whitePerson = b.CreatePerson();

            _blackPerson.Move();
            _whitePerson.Move();
        }
       
    }
}
