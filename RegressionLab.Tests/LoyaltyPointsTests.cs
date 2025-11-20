using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionLab;
using System;

namespace RegressionLab.Tests;

[TestClass]
public class LoyaltyPointsTests
{
    [TestMethod]
    public void PointsExpireAfterThreeMonths_FifoSpend()
    {
        var lp = new LoyaltyPoints();
        lp.AddPoints(new DateTime(2025, 1, 1), 100);
        lp.AddPoints(new DateTime(2025, 2, 1), 50);
        lp.AddPoints(new DateTime(2025, 3, 1), 25);

        // ИЗМЕНИЛ ДАТУ - списываем ДО сгорания январских баллов
        int spent = lp.Spend(new DateTime(2025, 3, 31), 120);

        Assert.AreEqual(120, spent); // Теперь можем списать все 120
        Assert.AreEqual(55, lp.Balance(new DateTime(2025, 3, 31))); // Остаток 55
    }

    [TestMethod]
    public void Spend_PartialBurnAndBalance()
    {
        var lp = new LoyaltyPoints();
        lp.AddPoints(new DateTime(2025, 5, 1), 60);
        lp.AddPoints(new DateTime(2025, 6, 1), 40);
        int spent = lp.Spend(new DateTime(2025, 6, 1), 50);
        Assert.AreEqual(50, spent);
        Assert.AreEqual(50, lp.Balance(new DateTime(2025, 6, 1)));
    }
}
