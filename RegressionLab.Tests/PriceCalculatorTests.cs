using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionLab;
using System;

namespace RegressionLab.Tests;

[TestClass]
public class PriceCalculatorTests
{
    [TestMethod]
    public void CalculateFinal_DiscountBeforeVat_RoundsAwayFromZero()
    {
        decimal result = PriceCalculator.CalculateFinal(100m, 0.20m, 15m);
        Assert.AreEqual(102.00m, result);
    }

    [TestMethod]
    public void CalculateFinal_HandlesMidpointCorrectly()
    {
        decimal result = PriceCalculator.CalculateFinal(10m, 0.21m, 5m);
        Assert.AreEqual(11.50m, result);
    }
}
