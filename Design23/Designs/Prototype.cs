using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Design23.Designs
{
    //[ComVisible(true)]
    //public interface ICloneable
    //{
    //    /// <summary>Creates a new object that is a copy of the current instance.</summary>
    //    /// <returns>A new object that is a copy of this instance.</returns>
    //    /// <filterpriority>2</filterpriority>
    //    object Clone();
    //}
    public class Email : ICloneable
    {
        public string Receiver { get; set; }
        public string Body { get; set; }
        //Thread.Sleep(1000);
        //Debug.WriteLine("I 'am sleep right now {0} ", System.DateTime.Now);

        public object Clone()
        {
            try
            {
                return base.MemberwiseClone();
            }
            catch (Exception e)
            {
                // TODO Auto-generated catch block
               Debug.WriteLine(e.Message); ;
            }
            return null;
        }
        public List<string> ReceiverList { get; set; }
        public ArrayList ReceiverList2 { get; set; }
    }

   
}
