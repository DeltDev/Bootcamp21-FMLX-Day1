namespace StackExercise;

internal class CustomStringStack
{
    private string[] _arr;
    private int _size;
    
    public CustomStringStack()
    {
        _arr = Array.Empty<string>();
    }
    public CustomStringStack(int capacity)
    {
        _arr = new string[capacity];
    }

    public void Type(string word)
    {
        if (_size == _arr.Length)
        {
            GrowQueue(_size+1);
        }
        
        _arr[_size++] = word;
        
        Console.WriteLine($"Typed {word}");
    }
    
    public void Undo()
    {
        if (_size == 0)
        {
            Console.WriteLine("Stack is empty");
            return;
        }
        
        string lastItem = _arr[_size-1];
        Console.WriteLine($"Undid {lastItem}");
        
        _arr[_size-1] = "";
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
        string[] newArr = new string[capacity];
        Array.Copy(_arr, newArr, _size);
        _arr = newArr;
    }
}