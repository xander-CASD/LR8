using System;

namespace RegressionLab;

public static class TaxCalculator
{
    public static decimal ComputeAnnualTax(decimal annualIncome)
    {
        if (annualIncome <= 0m)
            return 0m;

        decimal tax = 0m;

        // Расчет по налоговым bracket'ам
        if (annualIncome > 10000m)
        {
            decimal bracket1 = Math.Min(annualIncome - 10000m, 40000m);
            tax += bracket1 * 0.10m;
        }

        if (annualIncome > 50000m)
        {
            decimal bracket2 = Math.Min(annualIncome - 50000m, 50000m);
            tax += bracket2 * 0.20m;
        }

        if (annualIncome > 100000m)
        {
            decimal bracket3 = annualIncome - 100000m;
            tax += bracket3 * 0.30m;
        }

        // Потолок налога
        return Math.Min(tax, 25000m);
    }
}