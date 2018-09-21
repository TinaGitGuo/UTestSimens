using System;
using System.Collections.Generic;
using System.Linq;
using DtoModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web3i.Controllers.Wechat;
using Business.Services;
using System.Web.Mvc;
using Business;

namespace Simens3iTest
{
    [TestClass]
    public class UnitTest3i
    {
        private Guid _userid=new Guid("1E9620C9-6DE7-4B09-933A-F7611840A454");
        private int _year= 2018;
        PersonalService _personalService = new PersonalService();
        public void Init(){
            _personalService.UserId = _userid;
            _personalService.Year = _year;
            _personalService.init();
        }
        public UnitTest3i()
        {
            Init();
        }
        [TestMethod]
        public void Test_personalService()
        {
           
            //List<DapartmentBONusModel> DapartmentBONusModels = _personalService.GetDapartmentBONusModel();
            //List<DapartmentEVAModel> DapartmentEVAModels = _personalService.GetDapartmentEVAModel();
            //List<DapartmentFullModel> DapartmentFull2Models = _personalService.GetDapartmentFull2Model();
            //List<DapartmentFullModel> DapartmentFullModels = _personalService.GetDapartmentFullModel();
            //List<PersonBONusModel> PersonBONusModels = _personalService.GetPersonBONusModel();
            //List<PersonEVAModel> PersonEVAModels = _personalService.GetPersonEVAModel();
            //List<PersonNumberModel> PersonNumberModels = _personalService.GetPersonNumberModel();

            long RankDepartment = _personalService.RankDepartment();
            long RankPersonal = _personalService.RankPersonal();
            decimal TotalBONus = _personalService.TotalBONus();
           
            // var  p = new WechatPersonalController(ps)  ;
            //var a = p.Index();


        }

        [TestMethod]
        public void Test_CompanyService()
        {
            List<DapartmentNumberModel> CompanyNumberModel = _personalService.GetCompanyNumberModel();
            List<DapartmentEVAModel> CompanyEVAModel = _personalService.GetCompanyEVAModel();
            List<DapartmentBONusModel> CompanyBONusModel = _personalService.GetCompanyBONusModel();
            List<PersonNumberModel> CompanyPersonalNumberModel = _personalService.GetCompanyPersonalNumberModel();
            List<PersonEVAModel> CompanyPersonalEVAModel = _personalService.GetCompanyPersonalEVAModel();
            List<PersonBONusModel> CompanyPersonalBONusModel = _personalService.GetCompanyPersonalBONusModel();
            List<CompanyFullModel> CompanyFullModel1Model = _personalService.GetCompanyFullModel1Model();
            List<CompanyFullModel> CompanyFullModel2Model = _personalService.GetCompanyFullModel2Model();

            Assert.IsNotNull(CompanyNumberModel);
            Assert.IsNotNull(CompanyEVAModel);
            Assert.IsNotNull(CompanyBONusModel);
            Assert.IsNotNull(CompanyPersonalNumberModel);
            Assert.IsNotNull(CompanyPersonalEVAModel);
            Assert.IsNotNull(CompanyPersonalBONusModel);
            Assert.IsNotNull(CompanyFullModel1Model);
            Assert.IsNotNull(CompanyFullModel2Model);
        }
        [Description("测试分页")]
        [TestMethod]
        public void Test_Page()
        {
            List<DapartmentFullModel> DapartmentFullModels = _personalService.GetDapartmentFullModel(1, 1 * 2);
            List<DapartmentFullModel> d = DapartmentFullModels.GroupBy(a => a.Id).SelectMany(c => c).ToList();
            Assert.AreEqual(2, DapartmentFullModels.Count());
            Assert.AreEqual(2, DapartmentFullModels.Count());
        }
    }
}
