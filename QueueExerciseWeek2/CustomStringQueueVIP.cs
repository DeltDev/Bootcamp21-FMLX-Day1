using System;




public class CustomStringQueueVIP
{
    private string[] _arr;
    private int _size;

    public CustomStringQueueVIP()
    {
        _arr = Array.Empty<string>();
    }
    public CustomStringQueueVIP(int capacity)
    {
        _arr = new string[capacity];
    }

    public void EnqueueVip(string item){
        if (_size == _arr.Length)
        {
            GrowQueue(_size+1);
        }
        

        _arr[_size++] = item;

        for(int i = _size-1; i>0; i--){
            (_arr[i], _arr[i-1]) =  (_arr[i-1], _arr[i]);
        }


        Console.WriteLine($"VIP Queued {item}");
    }

    public void Enqueue(string item)
    {
        if (_size == _arr.Length)
        {
            GrowQueue(_size+1);
        }
        
        _arr[_size++] = item;
        
        Console.WriteLine($"Queued {item}");
    }

    public void Process()
    {
        if (_size == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        
        string firstItem = _arr[0];
        Console.WriteLine($"Processed {firstItem}");
        for (int i = 1; i < _size; i++) {
            _arr[i-1] = _arr[i];
        }
        _size--;
    }

    private void GrowQueue(int capacity)
    {
        Console.WriteLine("Masuk GrowQueue");
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
        string[] newArr = new string[capacity];
        Array.Copy(_arr, newArr, _size);
        _arr = newArr;
    }
    
}