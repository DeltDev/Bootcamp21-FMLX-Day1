namespace LinkedListExercise;

public class CustomLinkedList
{
    public int? value { get; set; }
    public CustomLinkedList? next { get; set; }

    private Func<int,bool>? _printFilterRule;
    private Func<int,int,int>? _sortComparer;
    public CustomLinkedList()
    {
        this.value = null;
        this.next = null;
    }
    public CustomLinkedList(int value)
    {
        this.value = value;
        this.next = null;
    }

    public void Append(int value)
    {
        Console.WriteLine($"Appended {value}");
        if (this.value == null)
        {
            this.value = value;
            return;
        }
        CustomLinkedList newNode = new CustomLinkedList(value);
        CustomLinkedList currentNode = this;

        while (currentNode.next != null)
        {
            currentNode = currentNode.next;
        }
        
        currentNode.next = newNode;
    }

    public void Print()
    {
        Console.Write($"Sequence: ");
        CustomLinkedList? currentNode = this;
        while (currentNode != null)
        {
            if(_printFilterRule(currentNode.value.Value)){
                currentNode = currentNode.next;
                continue;
            }
            Console.Write(currentNode.value);
            if (currentNode.next != null)
            {
                Console.Write(" -> ");
            }
            currentNode = currentNode.next;
        }
        
        Console.WriteLine();
    }

    public void AddFilter(Func<int,bool> filterRule){
        _printFilterRule = filterRule;
    }

    public void SetSorting(Func<int,int,int> comparer){
        _sortComparer = comparer;
    }

    public void Sort(){
        List<int> values = new();
        CustomLinkedList currentNode = this;
        while (currentNode != null)
        {
            values.Add(currentNode.value.Value);
            currentNode = currentNode.next;
        }

        values.Sort((a,b) => _sortComparer(a,b));

        currentNode = this;
        int idx = 0;
        while (currentNode != null && idx<values.Count)
        {
            currentNode.value = values[idx];
            idx++;
            currentNode = currentNode.next;
        }
    }
}

