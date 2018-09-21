using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Email email = new Email();
            email.Receiver = "Tom";
            email.Body = "Body";//以及其他的相同的10个属性，例如发送方地址，唯一需要改变也许就是 接收方地址，接收人姓名

            int count = 5;
            while (count-- > 0)
            {
                Email emailclone = (Email)email.Clone();
                string origalStr = $"克隆前接收人：{emailclone.Receiver}";
                Debug.WriteLine(origalStr);
                emailclone.Receiver = $"接收人：{emailclone.Receiver} - {Guid.NewGuid().ToString().Substring(2, 3)} 和 {emailclone.Body}";
                Debug.WriteLine($"初始值： {email.Receiver}");
                Debug.WriteLine(emailclone.Receiver);
                //发送邮件需要时间
                Thread.Sleep(1000);
                Debug.WriteLine($"当前线程名 ： {Thread.CurrentThread.Name}  以及 当前时间 {System.DateTime.Now}");
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendEmail));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Email email = new Email();
            email.Receiver = "Tom";
            email.Body = "Body";//以及其他的相同的10个属性，例如发送方地址，唯一需要改变也许就是 接收方地址，接收人姓名

            int count = 4;

            void ToSendEmail(Email e)
            {
                Email emailclone = (Email)e.Clone();
                Debug.WriteLine($"初始值： {e.Receiver}");
                Debug.WriteLine($"克隆前接收人：{emailclone.Receiver}");
                Debug.WriteLine($"接收人：{emailclone.Receiver} - {Guid.NewGuid().ToString().Substring(2, 3)} 和 {emailclone.Body}");
                //发送邮件需要时间
                Debug.WriteLine($"当前线程名 ： {Thread.CurrentThread.ManagedThreadId}  以及 当前时间 {DateTime.Now}");
                Thread.Sleep(5000);
            }

            for (int i = 1; i <= count; i++)
            {
                Debug.WriteLine($"发送第{i}份邮件");
                Task.Run(() => ToSendEmail(email));
            }
            //            发送第1份邮件
            //发送第2份邮件
            //发送第3份邮件
            //发送第4份邮件
            //初始值： Tom
            //初始值： Tom
            //初始值： Tom
            //初始值： Tom
            //克隆前接收人：Tom
            //克隆前接收人：Tom
            //克隆前接收人：Tom
            //克隆前接收人：Tom
            //接收人：Tom - 0ef 和 Body
            //接收人：Tom - 914 和 Body
            //接收人：Tom - 6bb 和 Body
            //接收人：Tom - ea0 和 Body
            //当前线程名 ： 13  以及 当前时间 9 / 11 / 2018 2:32:59 PM
            //当前线程名 ： 14  以及 当前时间 9 / 11 / 2018 2:32:59 PM
            //当前线程名 ： 8  以及 当前时间 9 / 11 / 2018 2:32:59 PM
            //当前线程名 ： 9  以及 当前时间 9 / 11 / 2018 2:32:59 PM
        }
        private void SendEmail(object state)
        {
            Email email = new Email();
            email.Receiver = "Tom";
            email.Body = "Body";//以及其他的相同的10个属性，例如发送方地址，唯一需要改变也许就是 接收方地址，接收人姓名

            int count = 5;
            for (int i = 0; i <= count; i++)
            {
                Email emailclone = (Email)email.Clone();
                string origalStr = $"克隆前接收人：{emailclone.Receiver}";
                Debug.WriteLine(origalStr);
                emailclone.Receiver = $"接收人：{emailclone.Receiver} - {Guid.NewGuid().ToString().Substring(2, 3)} 和 {emailclone.Body}";
                Debug.WriteLine($"初始值： {email.Receiver}");
                Debug.WriteLine(emailclone.Receiver);
                //发送邮件需要时间
                //Thread.Sleep(1000);
                Debug.WriteLine($"当前线程名 ： {Thread.CurrentThread.Name}  以及 当前时间 {System.DateTime.Now}");
            }
        }
        [Description("浅拷贝")]
        [TestMethod]
        public void TestMethod4()
        {
            Email email = new Email();
            email.ReceiverList = new List<string> { "a", "b", "c" };
            Email emailclone = (Email)email.Clone();
            Debug.WriteLine($"拷贝前 {email.ReceiverList.Count()}");
            Debug.WriteLine($"拷贝后 {emailclone.ReceiverList.Count()}");

            email.ReceiverList2 = new ArrayList  { "a", "b", "c" };
            Email emailclone2 = (Email)email.Clone();
            Debug.WriteLine($"拷贝前 {email.ReceiverList2 }");
            Debug.WriteLine($"拷贝后 {emailclone2.ReceiverList2 }");//测试 可以拷贝
        }
    }
}
