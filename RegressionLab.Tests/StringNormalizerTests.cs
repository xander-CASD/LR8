using System.Text.RegularExpressions;

namespace RegressionLab;

public static class StringNormalizer
{
    public static string NormalizeProductCode(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return string.Empty;

        // Удаляем все не-буквенно-цифровые символы кроме пробелов
        string clean = Regex.Replace(raw, @"[^a-zA-Z0-9\s]", "");

        // Заменяем пробелы на дефисы, убираем лишние дефисы
        clean = Regex.Replace(clean, @"\s+", "-");
        clean = Regex.Replace(clean, @"-+", "-"); // Объединяем множественные дефисы
        clean = clean.Trim('-');

        return clean.ToUpper();
    }
}