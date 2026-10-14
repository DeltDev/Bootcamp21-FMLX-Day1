

namespace CircularQueueExercise;

internal class CircularQueue2
{
    private int[] _queue;
    private int _front;
    const int Capacity = 3;
    private int _size;

    public CircularQueue2()
    {
        _queue = new int[Capacity];
        _front = 0;
        _size = 0;
    }

    public void Log(int value)
    {
        if (_size == Capacity)
        {
            OverwriteOldest(value);
            return;
        } else {
             int rear = (_front+_size) % Capacity;
            _queue[rear] = value;
            _size++;
        
            Console.WriteLine("Logged "+value);
        }
    }

    public void Read()
    {
        if (_size == 0)
        {
            Console.WriteLine("Buffer Empty");
            return;
        }
        
        int currentItem = _queue[_front];
        _front = (_front+1) % Capacity;
        _size--;
        
        Console.WriteLine("Read " + currentItem);
    }

    private void OverwriteOldest(int value){
        _queue[_front] = value;
        Console.WriteLine($"Overwritten oldest with {value}");
        _front = (_front+1) % Capacity;
    }
}