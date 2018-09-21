using System;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// 建造者模式
    /// </summary>
    [TestClass]
    public class BuilderTest
    {
        void ASequence(AbstractCarModel a)
        {
            a.Start();
            a.EngineBoom();
            a.Alarm();
        }
        void CSequence(AbstractCarModel a)
        {
            a.Start();
            a.EngineBoom();
            a.EngineBoom();
            a.Alarm();
            a.Stop();
        }
        [TestMethod]
        public void TestMethod1()
        {
            AbstractCarBuilder carABuilder =new CarABuilder(ASequence);

            AbstractCarModel carAModel = (CarAModel) carABuilder.GetCarModel();
            carAModel.Run();

            AbstractCarBuilder carBBuilder = new CarBBuilder(CSequence);

            AbstractCarModel carBModel = (CarBModel)carBBuilder.GetCarModel();
            carBModel.Run();

            //Debug Trace:
            //I' am going to run
            //A: Start
            //A: EngineBoom
            //A: Alarm
            //    I' am going to run
            //B: Start
            //B: EngineBoom
            //B: EngineBoom
            //B: Alarm
            //B: Stop
        }
        [TestMethod]
        public void TestMethod2()
        {
            CarAModel carAModel = new CarAModel();  ;
            // carAModel.Run();//不能run
            carAModel.Start();//不影响使用除run以外的方法
            //Debug Trace:
            //A: Start
        }
        [TestMethod]
        public void TestMethod3()
        {
            //可读性提高
            Director director = new Director();
            //1万辆A类型的奔驰车
            for (int i = 0; i < 10000; i++)
            {
                director.GetCarAModel().Run();
            }
            //100万辆B类型的宝马车
            for (int i = 0; i < 1000000; i++)
            {
                director.GetCarBModel().Run();
            }
            //1000万辆D类型的宝马车
            for (int i = 0; i < 10000000; i++)
            {
                director.GetCarDModel().Run();
            }
        }
    }
}
