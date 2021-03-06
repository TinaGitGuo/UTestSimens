﻿using System;
using System.Text;
using System.Collections.Generic;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests
{
    /// <summary>
    /// Summary description for ObserverTest
    /// </summary>
    [TestClass]
    public class ObserverTest
    {
        public ObserverTest()
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
            //
            // TODO: Add test logic here
            //
            IObserver liSi=new LiSi();
            IObserver wang=new Wang();
            IObserver liu=new Liu();

            IHanFeiZhi hanFeiZhi=new HanFeiZhi();
            ((IObservable)hanFeiZhi).Add(liSi);
            ((IObservable)hanFeiZhi).Add(wang);
            ((IObservable)hanFeiZhi).Add(liu);
            hanFeiZhi.Eat();
        }
    }
}
