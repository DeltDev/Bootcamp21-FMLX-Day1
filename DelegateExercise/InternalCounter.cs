namespace DelegateExercise;

public class InternalCounter
{
    public int Counter { get; private set; }

    public void IncrementCounter()
    {
        Counter++;
    }
}