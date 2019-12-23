﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;

using RaceHorologyLib;
using System;

namespace RaceHorologyLibTest
{


  [TestClass]
  public class UnitTest1
  {
    public TestContext TestContext
    {
      get { return _testContext; }
      set { _testContext = value; }
    }

    private TestContext _testContext;

    [TestMethod]
    public void TestMethod1()
    {
      Participant p = new Participant();
      p.Year = 1900;

      Assert.AreEqual(1900U, p.Year);
    }


    [TestMethod]
    public void TimeSpanAndFractions()
    {
      const double f1 = 0.000638078703703704;
      TimeSpan ts1 = RaceHorologyLib.Database.CreateTimeSpan(f1);
      Assert.AreEqual(new TimeSpan(0, 0, 0, 55, 130), ts1);
      TimeSpan ts2 = RaceHorologyLib.Database.CreateTimeSpan(RaceHorologyLib.Database.FractionForTimeSpan(ts1));
      Assert.AreEqual(ts1, ts2);

      TimeSpan ts3 = new TimeSpan(0, 0, 1, 55, 130);
      string s3 = ts3.ToString(@"mm\:s\,ff");
    }

    [TestMethod]
    public void ParseTimeSpan()
    {
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("01.211"), new TimeSpan(0, 0, 0, 1, 211));
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("01.11"), new TimeSpan(0, 0, 0, 1, 110));
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("01.1"), new TimeSpan(0, 0, 0, 1, 100));
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("02,21"), new TimeSpan(0, 0, 0, 2, 210));
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("02,3"), new TimeSpan(0, 0, 0, 2, 300));
      Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("1:01,111"), new TimeSpan(0, 0, 1, 1, 111));
      //Assert.AreEqual(TimeSpanExtensions.ParseTimeSpan("99.111"), new TimeSpan(0, 0, 0, 1, 211));
    }





  }
}
