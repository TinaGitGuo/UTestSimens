using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class AbstractFactoryTest
    {
        [TestMethod]
        [Description("未用 工厂模式")]
        public void TestMethod1()
        {
            AbstractWhiteHuman maleWhiteHuman = new MaleWhiteHuman();
            AbstractWhiteHuman femaleWhiteHuman = new FemaleWhiteHuman();

            maleWhiteHuman.GetSex();
            maleWhiteHuman.Move();

            femaleWhiteHuman.GetSex();
            femaleWhiteHuman.Move();

            AbstractBlackHuman maleBlackHuman = new MaleBlackHuman();
            AbstractBlackHuman femaleBlackHuman = new FemaleBlackHuman();

            maleBlackHuman.GetSex();
            maleBlackHuman.Move();

            femaleBlackHuman.GetSex();
            femaleBlackHuman.Move();
            //Output：
//            White Human, I 'am Men
//White Person is Moving
//White Human, I 'am Women
//White Person is Moving
//Black Human, I 'am Men
//Black Person is Moving
//Black Human, I 'am Women
//Black Person is Moving
        }
        [TestMethod]
        [Description("抽象工厂模式")]
        public void TestMethod2()
        {
            IHumanFactory maleFactory = new MaleFactory();
            IHumanFactory femaleFactory = new FemaleFactory();

            IHuman maleWhiteHuman=  maleFactory.CreateWhiteHuman();
            IHuman femaleWhiteHuman = femaleFactory.CreateWhiteHuman();

            maleWhiteHuman.GetSex();
            maleWhiteHuman.Move();

            femaleWhiteHuman.GetSex();
            femaleWhiteHuman.Move();

            IHuman maleBlackHuman = maleFactory.CreateBlackHuman();
            IHuman femaleBlackHuman = femaleFactory.CreateBlackHuman();
            maleBlackHuman.GetSex();
            maleBlackHuman.Move();
            femaleBlackHuman.GetSex();
            femaleBlackHuman.Move();
            //Output：
//            White Human, I 'am Men
//White Person is Moving
//White Human, I 'am Women
//White Person is Moving
//Black Human, I 'am Men
//Black Person is Moving
//Black Human, I 'am Women
//Black Person is Moving
        }
    }
}
