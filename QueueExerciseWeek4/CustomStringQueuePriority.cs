namespace QueueExerciseWeek4;



struct QueueItem
{
    public readonly string  Value;
    public readonly int Priority;

    public QueueItem(string Value, int Priority){
        this.Value = Value;
        this.Priority = Priority;
    }
}
internal class CustomStringQueuePriorityWeek4
{
    private QueueItem[] _arr;
    private int _size;
    private Dictionary<string, int> _rules;
    public CustomStringQueuePriorityWeek4()
    {
        _arr = Array.Empty<QueueItem>();
        _rules = new Dictionary<string, int>();
    }
    public CustomStringQueuePriorityWeek4(int capacity)
    {
        _arr = new QueueItem[capacity];
        _rules = new Dictionary<string, int>();
    }

    public void AddRule(string word, int priority)
    {
        _rules.Add(word, priority);
    }

    public void Enqueue(string val)
    {
        if (_size == _arr.Length)
        {
            GrowQueue(_size+1);
        }

        QueueItem item;
        if (_rules.ContainsKey(val))
        {
            item = new QueueItem(val,_rules[val]);
        }
        else
        {
            item = new QueueItem(val,0);
        }
        
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