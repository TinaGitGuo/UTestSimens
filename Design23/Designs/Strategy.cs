using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public interface IStrategy
    {
        void Operate();
    }
    public class BackDoor : IStrategy
    {
        public void Operate()
        {
            Debug.WriteLine("走后门");
        }
    }
    public class GivenGreenLight : IStrategy
    {
        public void Operate()
        {
            Debug.WriteLine("开路灯");
        }
    }
    public class BlockEnemy : IStrategy
    {
        public void Operate()
        {
            Debug.WriteLine("断后");
        }
    }

    public class StrategyContext
    {
        private readonly IStrategy _straegy;
        public StrategyContext(IStrategy strategy)
        {
            this._straegy = strategy;
        }
        public void Operate()
        {
            this._straegy.Operate();
        }
    }
    public interface ICalculator
    {
        int Exec(int a, int b);
    }
    public class Add : ICalculator
    {
        //加法运算
        public int Exec(int a, int b)
        {
            return a + b;
        }
    }
    public class Sub : ICalculator
    {
        //减法运算
        public int Exec(int a, int b)
        {
            return a - b;
        }
    }
    public class Context
    {
        private ICalculator cal = null;
        public Context(ICalculator _cal)
        {
            this.cal = _cal;
        }
        public int Exec(int a, int b )
        {
            return this.cal.Exec(a, b);
        }
    }

    public class Calculator
    {       
        public static Context Add()
        {
             return new Context(new Add());
        }
        public static Context Sub()
        {
            return new Context(new Sub());
        }
    }
}
 