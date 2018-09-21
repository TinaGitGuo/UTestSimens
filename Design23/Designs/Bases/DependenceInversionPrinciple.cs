using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Designs.Bases
{
    public interface ICar
    {
        void Run();
    }
    public class ACar : ICar
    {
        public void Run()
        {
            Debug.WriteLine("ACar is Running");
        }
    }
    public class BCar : ICar
    {
        public void Run()
        {
            Debug.WriteLine("BCar is Running");
        }
    }
    #region 依赖的三种方式：
    #region 接口注入
    public interface IDriver
    {
        void ToDrive(ICar car);
    }
    public class Driver : IDriver
    {
        [Description("接口注入")]
        public void ToDrive(ICar car)
        {
            car.Run();
        }
    }
    #endregion
    #region 构造函数注入
    public interface IDriver2
    {
        void ToDrive();
    }
    public class Driver2 : IDriver2
    {
        private readonly ICar _car;
        public Driver2(ICar car)
        {
            this._car = car;
        }
        [Description("构造函数注入")]
        public void ToDrive()
        {
            _car.Run();
        }
    }
    #endregion

    #region Setter注入
    public interface IDriver3
    {
        void SetCar(ICar car);
        void ToDrive();
    }
    public class Driver3 : IDriver3
    {
        private ICar _car;
        public void SetCar(ICar car)
        {
            this._car = car;
        }
        [Description("构造函数注入")]
        public void ToDrive()
        {
            _car.Run();
        }
    }
    #endregion
    #endregion

}
