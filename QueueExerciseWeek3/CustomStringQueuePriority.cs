namespace QueueExercise;

struct QueueItem
{
    public readonly string  Value;
    public readonly int Priority;

    public QueueItem(string Value, int Priority){
        this.Value = Value;
        this.Priority = Priority;
    }
}
internal class CustomStringQueuePriority
{
    private QueueItem[] _arr;
    private int _size;

    public CustomStringQueuePriority()
    {
        _arr = Array.Empty<QueueItem>();
    }
    public CustomStringQueuePriority(int capacity)
    {
        _arr = new QueueItem[capacity];
    }

    public void Enqueue(string val, int p)
    {
        if (_size == _arr.Length)
        {
            GrowQueue(_size+1);
        }
        
        QueueItem item = new QueueItem(val,p);
        _arr[_size++] = item;
        
        for (int i = _size-1; i >= 1; i--)
        {
            if(_arr[i].Priority > _arr[i-1].Priority){
                (_arr[i-1], _arr[i]) = (_arr[i], _arr[i-1]);
            }
        }
        Console.WriteLine($"Queued {item.Value} with priority {item.Priority}");
    }

    public void Process()
    {
        if (_size == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        
        QueueItem firstItem = _arr[0];
        Console.WriteLine($"Processed {firstItem.Value}");
        for (int i = 1; i < _size; i++) {
            _arr[i-1] = _arr[i];
        }
        _size--;
    }

    private void GrowQueue(int capacity)
    {
        const int growFactor = 2;
        const int minimumGrowth = 4;
        
        int newCapacity = _arr.Length * growFactor;
        if ((uint)newCapacity > Array.MaxLength)
        {
            newCapacity = Array.MaxLength;
        }
        
        newCapacity = Math.Max(newCapacity, _arr.Length + minimumGrowth);

        if (newCapacity < capacity)
        {
            newCapacity = capacity;
        }
        
        SetCapacity(newCapacity);
    }
    private void SetCapacity(int capacity)
    {
        QueueItem[] newArr = new QueueItem[capacity];
        Array.Copy(_arr, newArr, _size);
        _arr = newArr;
    }
    
}