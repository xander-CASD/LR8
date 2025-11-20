namespace RegressionLab;

public class LoyaltyPoints
{
    // BUGS: нет срока действия; сжигание LIFO; неверный баланс.
    private readonly Stack<(DateTime month, int points)> _stack = new();

    public void AddPoints(DateTime month, int points)
    {
        if (points <= 0) return;
        _stack.Push((new DateTime(month.Year, month.Month, 1), points));
    }

    public int Spend(DateTime onMonth, int requested)
    {
        int spent = 0;
        while (_stack.Count > 0 && spent < requested)
        {
            var (m, p) = _stack.Pop(); // Bug: LIFO
            int use = Math.Min(p, requested - spent);
            spent += use;
            int left = p - use;
            if (left > 0) _stack.Push((m, left));
        }
        return spent;
    }

    public int Balance(DateTime onMonth)
    {
        // Bug: просто просуммировать все
        return _stack.Sum(x => x.points);
    }
}
