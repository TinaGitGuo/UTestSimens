using System;
using System.Text;
using System.Collections.Generic;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simens3iTest.Simen3i
{
    /// <summary>
    /// Summary description for TestProposalDetail
    /// </summary>
    [TestClass]
    public class TestProposalDetail
    {

        public TestProposalDetail()
        {
            Init();
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            Init();
            _personalService.prvw_Proposal.ProposalId=new Guid("F020BAC0-1230-48D7-BCB8-05FD4366DE01");
            var a = _personalService.vw_Proposal();
         Assert.IsNotNull(a);
            var b = _personalService.vw_ProposalImage();
            Assert.IsNull(b);
            var c = _personalService.vw_ProposalComment();
            Assert.IsNull(c);
            var d = _personalService.vw_ProposalRecord();
            Assert.IsNotNull(d);
            int Comment;
            int Collection; int Praise;
             _personalService.CommentCollectionPraise(out Comment,out Collection,out Praise);
            Assert.IsNotNull(d);
            //
            // TODO: Add test logic here
            //
        }

        private Guid _userid = new Guid("1E9620C9-6DE7-4B09-933A-F7611840A454");
        private int _year = 2018;
        PersonalService _personalService = new PersonalService();
        public void Init()
        {
            _personalService.UserId = _userid;
            _personalService.Year = _year;
            _personalService.init();
           
        }
        
    }
}
