using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public interface IObserver
    {
        void Update(string value);
    }
    public interface IHanFeiZhi
    {
        void Eat();
        void Speak();
    }
    public class HanFeiZhi : IHanFeiZhi, IObservable
    {
        private ArrayList _observerList = new ArrayList();
    
        public void Eat()
        {
            Debug.WriteLine("韩非子正在吃饭");
            
            this.NotifyObservers("韩非子在吃饭");
        }

        public void Speak()
        {
            Debug.WriteLine("韩非子正在演讲");
            this.NotifyObservers("韩非子在演讲");
        }
        public void Add(IObserver observer)
        {
            _observerList.Add(observer);
        }

        public void Delete(IObserver observer)
        {
            _observerList.Remove(observer);
        }

        public void NotifyObservers(string value)
        {
            foreach (IObserver o in _observerList)
            {
              o.Update(value);
            }
        }
    }
    public interface IObservable
    {
        //增加一个观察者
          void Add(IObserver observer);
        //删除一个观察者
          void Delete(IObserver observer);
        //既然要观察，我发生改变了他也应该有所动作，通知观察者
          void NotifyObservers(string value);
    }
    public class LiSi : IObserver //,IObservable<LiSi>
    {
        public void Update(string value)
        {
           Debug.WriteLine("李斯正在观察韩非子");
           this.ReportToQinShiHuang(value);
           Debug.WriteLine("李斯汇报完毕");
        }
        private void ReportToQinShiHuang(string reportContext)
        {
            Debug.WriteLine("李斯：报告，秦老板！韩非子有活动了--->" + reportContext);
        }
        //public IDisposable Subscribe(IObserver<LiSi> observer)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class Wang : IObserver
    {
        public void Update(string value)
        {
          this.Cry();
        }

        private void Cry()
        {
            Debug.WriteLine("王正在哭");
        }
    }
    public class Liu : IObserver
    {
        public void Update(string value)
        {
            this.Happy();
        }
        private void Happy()
        {
            Debug.WriteLine("正在开心");
        }
    }

    public class LiSi2:IObservable<Wang>
    {
        public IDisposable Subscribe(IObserver<Wang> observer)
        {
            throw new NotImplementedException();
        }
    }
}
