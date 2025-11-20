namespace RegressionLab;

public static class PriceCalculator
{
    // BUGS: 1) НДС применяется ДО скидки 2) Банковское округление (ToEven) и 3) позволяет незаметно вводить неверные данные.
    public static decimal CalculateFinal(decimal netPrice, decimal vatRate, decimal discountPercent)
    {
        // Bug: отсутствует проверка
        decimal vat = netPrice * vatRate;
        decimal gross = netPrice + vat;
        decimal afterDiscount = gross * (1 - discountPercent / 100m);
        // Bug: округление ToEven
        return Math.Round(afterDiscount, 2, MidpointRounding.ToEven);
    }
}
