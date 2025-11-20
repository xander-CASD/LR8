using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionLab;
using System;

namespace RegressionLab.Tests;

[TestClass]
public class DateUtilsTests
{
    [TestMethod]
    public void OverlapMinutes_NormalCase()
    {
        var a1 = new DateTime(2025, 10, 1, 9, 0, 0);
        var a2 = new DateTime(2025, 10, 1, 12, 0, 0);
        var b1 = new DateTime(2025, 10, 1, 11, 0, 0);
        var b2 = new DateTime(2025, 10, 1, 13, 0, 0);
        Assert.AreEqual(60, DateUtils.OverlapMinutes(a1, a2, b1, b2));
    }

    [TestMethod]
    public void OverlapMinutes_EqualRanges_AreNonNegative()
    {
        var a1 = new DateTime(2025, 10, 1, 10, 0, 0);
        var a2 = new DateTime(2025, 10, 1, 10, 0, 0);
        var b1 = new DateTime(2025, 10, 1, 9, 30, 0);
        var b2 = new DateTime(2025, 10, 1, 10, 30, 0);
        Assert.AreEqual(0, DateUtils.OverlapMinutes(a1, a2, b1, b2));
    }

    [TestMethod]
    public void OverlapMinutes_InvertedRanges_Normalized()
    {
        var a1 = new DateTime(2025, 10, 1, 12, 0, 0);
        var a2 = new DateTime(2025, 10, 1, 9, 0, 0);
        var b1 = new DateTime(2025, 10, 1, 10, 0, 0);
        var b2 = new DateTime(2025, 10, 1, 11, 0, 0);
        Assert.AreEqual(60, DateUtils.OverlapMinutes(a1, a2, b1, b2));
    }
}
