using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public interface IUserInfo
    {
        //获得用户姓名
        string GetUserName();
        //获得家庭地址
        string GetHomeAddress();
        //手机号码，这个太重要，手机泛滥呀
        string GetMobileNumber();
        //办公电话，一般是座机
        string GetOfficeTelNumber();
        //这个人的职位是什么
        string GetJobPosition();
        //获得家庭电话，这有点不好，我不喜欢打家庭电话讨论工作
        string GetHomeTelNumber();
    }
    public class User
    {
        public string UserName { get; set; }
        public string HomeAddress { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeTelNumber { get; set; }
        public string JobPosition { get; set; }
        public string HomeTelNumber { get; set; }
    }
    public class UserInfo : IUserInfo
    {
        private User _user;
        public UserInfo(User user)
        {
            this._user = user;
        }
        public string GetUserName()
        {
            return this._user.UserName;
        }

        public string GetHomeAddress()
        {
            throw new NotImplementedException();
        }

        public string GetMobileNumber()
        {
            throw new NotImplementedException();
        }

        public string GetOfficeTelNumber()
        {
            throw new NotImplementedException();
        }

        public string GetJobPosition()
        {
            throw new NotImplementedException();
        }

        public string GetHomeTelNumber()
        {
            throw new NotImplementedException();
        }
    }
    public interface IOuterUserBaseInfo
    {
        //基本信息，比如名称、性别、手机号码等
        Hashtable GetUserBaseInfo();
    }
    public interface IOuterUserHomeInfo
    {
        //用户的家庭信息
        Hashtable GetUserHomeInfo();
    }
    public interface IOuterUserOfficeInfo
    {
        //工作区域信息
        Hashtable GetUserOfficeInfo();
    }
    public class OuterUserBaseInfo : IOuterUserBaseInfo
    {
        /* 
         * 用户的基本信息
         */
        public Hashtable GetUserBaseInfo()
        {
            Hashtable baseInfoMap = new Hashtable();
            baseInfoMap.Add("userName", "这个员工叫混世魔王...");
            baseInfoMap.Add("mobileNumber", "这个员工电话是...");
            return baseInfoMap;
        }
    }
    public class OuterUserHomeInfo : IOuterUserHomeInfo
    {
        /* 
         * 员工的家庭信息
         */
        public Hashtable GetUserHomeInfo()
        {
            Hashtable homeInfo = new Hashtable();
            homeInfo.Add("homeTelNumbner", "员工的家庭电话是...");
            homeInfo.Add("homeAddress", "员工的家庭地址是...");
            return homeInfo;
        }
    }
    public class OuterUserOfficeInfo : IOuterUserOfficeInfo
    {
        /* 
         * 员工的工作信息，比如，职位等
         */
        public Hashtable GetUserOfficeInfo()
        {
            Hashtable officeInfo = new Hashtable();
            officeInfo.Add("jobPosition", "这个人的职位是BOSS...");
            officeInfo.Add("officeTelNumber", "员工的办公电话是...");
            return officeInfo;
        }
    }
    public class OuterUserInfo : IUserInfo
    {
        //源目标对象
        private IOuterUserBaseInfo baseInfo = null;     //员工的基本信息
        private IOuterUserHomeInfo homeInfo = null;     //员工的家庭信息
        private IOuterUserOfficeInfo officeInfo = null; //工作信息
                                                        //数据处理
        private Hashtable baseMap = null;
        private Hashtable homeMap = null;
        private Hashtable officeMap = null;
        //构造函数传递对象
        public OuterUserInfo(IOuterUserBaseInfo _baseInfo, IOuterUserHomeInfo _homeInfo, IOuterUserOfficeInfo _officeInfo)
        {
            this.baseInfo = _baseInfo;
            this.homeInfo = _homeInfo;
            this.officeInfo = _officeInfo;
            //数据处理
            this.baseMap = this.baseInfo.GetUserBaseInfo();
            this.homeMap = this.homeInfo.GetUserHomeInfo();
            this.officeMap = this.officeInfo.GetUserOfficeInfo();
        }
        //家庭地址
        public string GetHomeAddress()
        {
            string homeAddress = (string)this.homeMap["homeAddress"];
            Debug.WriteLine(homeAddress);
            return homeAddress;
        }
        //家庭电话号码
        public string GetHomeTelNumber()
        {
            string homeTelNumber = (string)this.homeMap["homeTelNumber"];
            Debug.WriteLine(homeTelNumber);
            return homeTelNumber;
        }
        //职位信息
        public string GetJobPosition()
        {
            string jobPosition = (string)this.officeMap["jobPosition"];
            Debug.WriteLine(jobPosition);
            return jobPosition;
        }
        //手机号码
        public string GetMobileNumber()
        {
            string mobileNumber = (string)this.baseMap["mobileNumber"];
            Debug.WriteLine(mobileNumber);
            return mobileNumber;
        }
        //办公电话
        public string GetOfficeTelNumber()
        {
            string officeTelNumber = (string)this.officeMap["officeTelNumber"];
            Debug.WriteLine(officeTelNumber);
            return officeTelNumber;
        }
        // 员工的名称
        public string GetUserName()
        {
            string userName = (string)this.baseMap["userName"];
            Debug.WriteLine(userName);
            return userName;
        }
    }
}
