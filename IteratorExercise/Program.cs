foreach (int i in GenerateNumbers())
{
    Console.WriteLine(i);
}

Console.WriteLine("Fibonaccis from 1 to 10");
foreach (int fib in Fibonaccis(10))
{
    Console.WriteLine(fib);
}

Console.WriteLine("Fibonacci from 1 to 10 but odd fibonaccis only");
foreach (int fib in OddNumbersOnly(Fibonaccis(10)))
{
    Console.WriteLine(fib);
}
IEnumerable<int> OddNumbersOnly(IEnumerable<int> sequence)
{
    foreach (int x in sequence)
    {
        if (x % 2 == 1)
        {
            yield return x;
        }
    }
}
IEnumerable<int> Fibonaccis(int fibCount)
{
    for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
    {
        yield return prevFib;
        int newFib = prevFib + curFib;
        prevFib = curFib;
        curFib = newFib;
    }
}
IEnumerable<int> GenerateNumbers()
{
    try
    {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield break;
        yield return 5;
    }

    finally
    {
        Console.WriteLine("Anjay");
    }
    
}