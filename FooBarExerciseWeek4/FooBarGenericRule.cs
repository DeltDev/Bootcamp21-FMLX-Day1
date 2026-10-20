namespace FooBarExerciseWeek4;

public class FooBarGenericRule
{
    private Action<int>? _rules;


    private bool _matchedThisNumber;

    public void AddRule(int divisor, string output)
    {
        Action<int> rule = (int x) => {
            if (x % divisor == 0)
            {
                Console.Write(output);
                MarkMatched();
            }};
        _rules += rule;
    }

    private void MarkMatched()
    {
        _matchedThisNumber = true;
    }

    public void Evaluate(int x)
    {
        _rules!(x);
    }

    public void Generate(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            _matchedThisNumber = false;

            _rules!(i);

            if (!_matchedThisNumber)
            {
                Console.Write(i);
            }
            if (i != x)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}