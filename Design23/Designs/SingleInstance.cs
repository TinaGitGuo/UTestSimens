using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Design23.Designs
{
    public class SingleInstance
    {
        private static SingleInstance _pInstance;
        private SingleInstance()
        {
          
        }
        public static SingleInstance GetInstance()
        {
            lock (_pInstance)
            {
                if (_pInstance == null)
                {
                    Debug.WriteLine("新的实例");
                    _pInstance = new SingleInstance();
                }
                Debug.WriteLine("原来的实例");
                return _pInstance;
            }
        }
    }
}
