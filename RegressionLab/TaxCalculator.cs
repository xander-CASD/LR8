namespace RegressionLab;

public static class TaxCalculator
{
    // BUGS: неправильная математика в скобках, ограничение не применено.
    public static decimal ComputeAnnualTax(decimal income)
    {
        if (income <= 0) return 0;
        // Bug: фиксированная ставка 15% без ограничения
        return income * 0.15m;
    }
}
