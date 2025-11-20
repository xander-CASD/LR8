namespace RegressionLab;

public static class DateUtils
{
    // BUGS: нет нормализации инвертированных диапазонов; возвращено отрицательное перекрытие; округляет минуты.
    public static int OverlapMinutes(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
    {
        // Нормализуем интервалы (исправление бага с инвертированными диапазонами)
        if (start1 > end1) (start1, end1) = (end1, start1);
        if (start2 > end2) (start2, end2) = (end2, start2);

        var start = start1 > start2 ? start1 : start2;
        var end = end1 < end2 ? end1 : end2;

        // Если нет пересечения - возвращаем 0 (исправление бага с отрицательными значениями)
        if (start >= end)
            return 0;

        // Округляем ВНИЗ (Floor) вместо ВВЕРХ (Ceiling) - исправление бага с округлением
        return (int)Math.Floor((end - start).TotalMinutes);
    }
}