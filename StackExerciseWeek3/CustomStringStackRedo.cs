

namespace StackExercise;

internal class CustomStringStackRedo
{
    const int MAX_STACK_SIZE = 3;
    private string[] _arr;
    private int _size;
    private static CustomStringStackRedo _redoStack;
    
    public CustomStringStackRedo()
    {
        _arr = new string[MAX_STACK_SIZE];
        
    }
    public CustomStringStackRedo(CustomStringStackRedo redoStack)
    {
        _arr = new string[MAX_STACK_SIZE];
        _redoStack = redoStack;
    }

    public void Type(string word)
    {
        this.PushInternal(word);
        _redoStack.ClearStack();
        Console.WriteLine($"Typed {word}");
    }
    
    public void Undo()
    {
        this.PopInternal(out string top);

        if (top != null)
        {
            Console.WriteLine($"Undid {top}");
        } else {
            Console.WriteLine("Stack is empty");
        }
        
        _redoStack.PushInternal(top); //masukkan ke stack redo
    }

    public void Redo(){
        _redoStack.PopInternal(out string top);

        if (top!=null)
        {
            Console.WriteLine($"Redid {top}");
        } else {
            Console.WriteLine("Nothing to Redo");
        }

        this.PushInternal(top);
    }

    protected void PushInternal(string word){
        if (_size == MAX_STACK_SIZE)
        {
            DropBottom();
        } else {
            _size++;
        }
        _arr[_size-1] = word;
    }
    protected void PopInternal(out string top){
        if (_size == 0)
        {
            top = null;
            return;
        }
        
        top = _arr[_size-1];
    
        _arr[_size-1] = "";
        _size--;
    }

    protected void ClearStack(){
        this._arr = new string[MAX_STACK_SIZE];
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