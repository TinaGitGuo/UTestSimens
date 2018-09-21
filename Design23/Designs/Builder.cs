using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Designs
{
    /// <summary>
    /// 建造者模式
    /// </summary>
    public abstract class AbstractCarModel
    {
        protected AbstractCarModel()
        {
        }
        protected AbstractCarModel(Action<AbstractCarModel> sequence)
        {
            //如果需要调 run()方法，需调用此构造函数
            this._sequence = sequence;
        }
        /// <summary>
        /// 执行的顺序
        /// </summary>
        private readonly Action<AbstractCarModel> _sequence  ;

        public abstract void Start();
        public abstract void Stop();
        public abstract void Alarm();
        public abstract void EngineBoom();
     
        public void Run()
        {
            Debug.WriteLine("I' am going to run");
            this._sequence(this);
        }
    }

    public class CarAModel: AbstractCarModel
    {
        public CarAModel()
        {

        }
        public CarAModel(Action<AbstractCarModel> sequence):base(sequence)
        {
            //如果需要调 父类的 run()方法，需调用此构造函数
        }
        public override void Start()
        {
           Debug.WriteLine("A: Start");
        }

        public override void Stop()
        {
           Debug.WriteLine("A: Stop"); 
        }

        public override void Alarm()
        {
            Debug.WriteLine("A: Alarm");
        }

        public override void EngineBoom()
        {
            Debug.WriteLine("A: EngineBoom");
        }
    }
    public class CarBModel : AbstractCarModel
    {
        public CarBModel()
        {

        }
        public CarBModel(Action<AbstractCarModel> sequence) : base(sequence)
        {
            //如果需要调 run()方法，需调用此构造函数
        }
        public override void Start()
        {
            Debug.WriteLine("B: Start");
        }
        public override void Stop()
        {
            Debug.WriteLine("B: Stop");
        }

        public override void Alarm()
        {
            Debug.WriteLine("B: Alarm");
        }

        public override void EngineBoom()
        {
            Debug.WriteLine("B: EngineBoom");
        }
    }
    public abstract class AbstractCarBuilder
    {
        public AbstractCarModel Car;
        public AbstractCarModel GetCarModel()
        {
            return this.Car;
        }
    }

    public class CarABuilder : AbstractCarBuilder
    {//建造者模式与工厂模式的区别：建造者模式 注意对象的顺序，而工厂模式只返回对象
        public CarABuilder(Action<AbstractCarModel> sequence)  
        {
            this.Car = new CarAModel(sequence);
        }
    }
    public class CarBBuilder : AbstractCarBuilder
    {
        public CarBBuilder(Action<AbstractCarModel> sequence) 
        {
            this.Car = new CarBModel(sequence);
        }
    }

    public class Director
    {
        private AbstractCarBuilder _carABuilder  ;
        private AbstractCarBuilder _carBBuilder  ;

        public CarAModel GetCarAModel()
        {
              void Sequence(AbstractCarModel a)
            {
                a.Start();
                a.EngineBoom();
                a.Alarm();
            }
           this. _carABuilder=new CarABuilder(Sequence);
           return (CarAModel)this._carABuilder.GetCarModel();
        }
        public CarBModel GetCarBModel()
        {
            void Sequence(AbstractCarModel a)
            {
                a.Start();
                a.EngineBoom();
                a.EngineBoom();
                a.Alarm();
                a.Stop();
            }
           this. _carBBuilder = new CarBBuilder(Sequence);
            return (CarBModel)this._carBBuilder.GetCarModel();
        }
        public CarBModel GetCarDModel()
        {
            void Sequence(AbstractCarModel a)
            {
                a.Start();
                a.Stop();
            }
            this._carBBuilder = new CarBBuilder(Sequence);
            return (CarBModel)this._carBBuilder.GetCarModel();
        }
    }
}
