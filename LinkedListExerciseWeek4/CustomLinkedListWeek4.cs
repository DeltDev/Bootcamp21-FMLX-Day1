namespace LinkedListExerciseWeek4;


public class CustomLinkedListWeek4
{
    public int? value { get; set; }
    public CustomLinkedListWeek4? next { get; set; }

    private List<Func<int,bool>> _printFilterRule;
    private Func<int,int,int>? _sortComparer;
    public CustomLinkedListWeek4()
    {
        this.value = null;
        this.next = null;
        _printFilterRule = new List<Func<int,bool>>();
    }
    public CustomLinkedListWeek4(int value)
    {
        this.value = value;
        this.next = null;
        _printFilterRule = new List<Func<int,bool>>();
    }

    public void Append(int value)
    {
        Console.WriteLine($"Appended {value}");
        if (this.value == null)
        {
            this.value = value;
            return;
        }
        CustomLinkedListWeek4 newNode = new CustomLinkedListWeek4(value);
        CustomLinkedListWeek4 currentNode = this;

        while (currentNode.next != null)
        {
            currentNode = currentNode.next;
        }
        
        currentNode.next = newNode;
    }

    public void Print()
    {
        Console.Write("Sequence: ");

        CustomLinkedListWeek4? currentNode = this;
        bool firstPrinted = true;

        while (currentNode != null)
        {
            bool checkFilter = true;

            foreach (Func<int, bool> filter in _printFilterRule)
            {
                if (!filter(currentNode.value!.Value))
                {
                    checkFilter = false;
                    break;
                }
            }

            if (checkFilter)
            {
                if (!firstPrinted)
                {
                    Console.Write(" -> ");
                }

                Console.Write(currentNode.value);
                firstPrinted = false;
            }

            currentNode = currentNode.next;
        }

        Console.WriteLine();
    }

    public void AddFilter(Func<int,bool> filterRule){
        _printFilterRule.Add(filterRule);
    }

    public void SetSorting(Func<int,int,int> comparer){
        _sortComparer = comparer;
    }

    public void Sort(){
        List<int> values = new();
        CustomLinkedListWeek4? currentNode = this;
        while (currentNode != null)
        {
            values.Add(currentNode.value!.Value);
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
