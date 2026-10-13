namespace MulticastExercise;
public class Util
{
    public static void HeavyWork(Action<int> progress)
    {
        for (int i = 0; i <= 10; i++)
        {
            progress(i * 10);
            System.Threading.Thread.Sleep(5000);
        }
    }

    public static void HeavyCalculation(Func<int, int, int> multiCalculation)
    {
        int result = multiCalculation(8, 5);
        Console.WriteLine(result);
    }
}

