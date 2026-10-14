namespace StackExercise;

internal class CustomStringStackDrop
{
    const int MAX_STACK_SIZE = 3;
    private string[] _arr;
    private int _size;
    
    public CustomStringStackDrop()
    {
        _arr = new string[MAX_STACK_SIZE];
    }

    public void Type(string word)
    {
        if (_size == MAX_STACK_SIZE)
        {
            DropBottom();
        } else {
            _size++;
        }
        _arr[_size-1] = word;
        
        Console.WriteLine($"Typed {word}");
    }
    
    public void Undo()
    {
        if (_size == 0)
        {
            Console.WriteLine("Stack is empty");
            return;
        }
        
        string top = _arr[_size-1];
        Console.WriteLine($"Undid {top}");
        
        _arr[_size-1] = "";
        _size--;
    }
    
    private void SetCapacity(int capacity)
    {
        string[] newArr = new string[capacity];
        Array.Copy(_arr, newArr, _size);
        _arr = newArr;
    }

    private void DropBottom(){
        string bottom = _arr[0];
        _arr[0] = "";

        for(int i = 1; i<_size; i++){
            (_arr[i-1] , _arr[i]) = (_arr[i], _arr[i-1]);
        }

        Console.Write($"Dropped Bottom, ");
    }                                                           
}