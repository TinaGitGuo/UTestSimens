using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{

    public interface IHummer
    {
        void Start();
        void Stop();
        void Alarm();
        void EngineBoom();
        void Run();
    }

    public class HummerH1 : IHummer
    {
        public void Start()
        {
            Debug.WriteLine("HummerH1 is Starting");
        }

        public void Stop()
        {
            Debug.WriteLine("HummerH1 is Stoping");

        }

        public void Alarm()
        {
            Debug.WriteLine("HummerH1 is Alarmming");
        }

        public void EngineBoom()
        {
            Debug.WriteLine("HummerH1 is EngineBoom");
        }

        public void Run()
        {
            this.Start();
            this.EngineBoom();
            this.Alarm();
            this.Stop();
        }
    }
    public class HummerH2 : IHummer
    {
        public void Start()
        {
            Debug.WriteLine("HummerH2 is Starting");
        }

        public void Stop()
        {
            Debug.WriteLine("HummerH2 is Stoping");
        }

        public void Alarm()
        {
            Debug.WriteLine("HummerH2 is Alarmming");
        }

        public void EngineBoom()
        {
            Debug.WriteLine("HummerH2 is EngineBoom");
        }

        public void Run()
        {
            this.Start();
            this.EngineBoom();
            this.Alarm();
            this.Stop();
        }
    }

    #region 模板模式
    public abstract class AbstractHummer
    {
        public abstract void Start();
        public abstract void Stop();
        public abstract void Alarm();
        public abstract void EngineBoom();
        public void Run()
        {
            this.Start();
            this.EngineBoom();
            this.Alarm();
            this.Stop();
        }
    }
    public class HummerH3 : AbstractHummer
    {
        public override void Start()
        {
            Debug.WriteLine("HummerH3 is Starting");
        }

        public override void Stop()
        {
            Debug.WriteLine("HummerH3 is Stoping");

        }

        public override void Alarm()
        {
            Debug.WriteLine("HummerH3 is Alarmming");
        }

        public override void EngineBoom()
        {
            Debug.WriteLine("HummerH3 is EngineBoom");
        }
    }
    public class HummerH4 : AbstractHummer
    {
        public override void Start()
        {
            Debug.WriteLine("HummerH4 is Starting");
        }
        public override void Stop()
        {
            Debug.WriteLine("HummerH4 is Stoping");
        }
        public override void Alarm()
        {
            Debug.WriteLine("HummerH4 is Alarmming");
        }
        public override void EngineBoom()
        {
            Debug.WriteLine("HummerH4 is EngineBoom");
        }
    }
    #endregion
}
