using System.Text.RegularExpressions;

namespace RegressionLab;

public static class StringNormalizer
{
    // BUGS: сохраняет подчеркивания и строчные буквы, множественные разделители не сворачиваются.
    public static string NormalizeProductCode(string? raw)
    {
        if (string.IsNullOrEmpty(raw))
            return string.Empty;

        var s = raw.Trim();

        // Заменяем пробелы на дефисы (но это не полное решение)
        s = Regex.Replace(s, @"\s+", "-");

        // TODO: Нужно также удалить все не-буквенно-цифровые символы кроме дефисов
        // TODO: И привести к верхнему регистру
        // TODO: И объединить множественные дефисы

        return s;
    }
}