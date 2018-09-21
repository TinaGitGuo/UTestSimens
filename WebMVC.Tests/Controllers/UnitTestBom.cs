using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.Controllers;

namespace WebMVC.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTestBom
    /// </summary>
    [TestClass]
    public class UnitTestBom
    {
        public UnitTestBom()
        {
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
        BomController c = new BomController();
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
            c.ExportData();
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void TestMethod2()
        {
            c.ExportData();
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void TestMethod3()
        {
            c.ExportData();
            //
            // TODO: Add test logic here
            //
        }
        [TestMethod]
        public void TestMethod4()
        {
            c.ExportData();
            //
            // TODO: Add test logic here
            //
        }
    }
}
