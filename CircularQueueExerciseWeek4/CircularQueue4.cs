namespace CircularQueueExerciseWeek4;



internal class CircularQueue4
{
    private int[] _queue;
    private int _front;
    private int _capacity = 3;
    private int _size;
    private bool _isOverwriteEnabled;
    public CircularQueue4()
    {
        _queue = new int[_capacity];
        _front = 0;
        _size = 0;
        _isOverwriteEnabled = true;
    }

    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
        _queue = new int[_capacity];
        _front = 0;
        _size = 0;
        _isOverwriteEnabled = true;
    }

    public void SetOverwritePolicy(bool isOverwriteEnabled)
    {
        _isOverwriteEnabled = isOverwriteEnabled;
    }
    public void Log(int value)
    {
        if (_size == _capacity)
        {
            if (_isOverwriteEnabled)
            {
                OverwriteOldest(value);
            }
            else
            {
                Console.WriteLine("Rejected. Buffer Full");
            }
            return;
        } else {
            int rear = (_front+_size) % _capacity;
            _queue[rear] = value;
            _size++;
        
            Console.WriteLine("Logged "+value);

            if(_size == _capacity){
                Console.WriteLine("Critical: Buffer Full");
            } 
            if(_size == (int)Math.Round((double)_capacity * 66/100)){
                Console.WriteLine("Warning: Buffer at 66%");
            }
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
        _front = (_front+1) % _capacity;
        _size--;
        
        Console.WriteLine("Read " + currentItem);
    }

    private void OverwriteOldest(int value){
        _queue[_front] = value;
        Console.WriteLine($"Overwritten oldest with {value}");
        _front = (_front+1) % _capacity;
    }
}