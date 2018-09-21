using System;
using System.Diagnostics;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //从数据库中查到101个
            for (int i = 0; i < 101; i++)
            {
                //外系统的人员信息
                IOuterUserBaseInfo baseInfo = new OuterUserBaseInfo();
                IOuterUserHomeInfo homeInfo = new OuterUserHomeInfo();
                IOuterUserOfficeInfo officeInfo = new OuterUserOfficeInfo();
                //传递三个对象
                IUserInfo youngGirl = new OuterUserInfo(baseInfo, homeInfo, officeInfo);

                youngGirl.GetUserName();
                //这个员工叫混世魔王...
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            //从数据库中查到101个
            for (int i = 0; i < 101; i++)
            {
                User a = new User { HomeAddress = "临湖大道", HomeTelNumber = "010", JobPosition = "员工", MobileNumber = "190", OfficeTelNumber = "730", UserName = "张三" + i };
                //传递1个对象
                IUserInfo youngGirl = new UserInfo(a);
                Debug.WriteLine($"姓名：{youngGirl.GetUserName()} ");
            }
            //姓名：张三16 
        }
    }
}
