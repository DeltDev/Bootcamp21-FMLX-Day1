namespace LinkedListExercise;

internal class CustomLinkedList
{
    public int? Value { get; set; }
    public CustomLinkedList? Next { get; set; }
    public CustomLinkedList? Previous {get; set;}
    public CustomLinkedList? First {get; set;}
    public CustomLinkedList()
    {
        this.Value = null;
        this.Next = null;
        this.Previous = null;
        this.First = this;
    }
    public CustomLinkedList(int value, CustomLinkedList? previous)
    {
        this.Value = value;
        this.Next = null;
        this.Previous = previous;
    }

    public CustomLinkedList(int value){
        this.Value = value;
        this.Next = null;
        this.Previous = null;

    }

    public void Insert(int value)
    {
        Console.WriteLine($"Inserted {value}");
        CustomLinkedList newNode = new CustomLinkedList(value);
        if (this.First.Value == null)
        {
            this.First = newNode;
            return;
        }
        
        CustomLinkedList? currentNode = this.First;
        CustomLinkedList? previousNode = null;
        while (currentNode != null && newNode.Value > currentNode.Value )
        {
            Console.WriteLine($"current value {currentNode?.Value}");
            previousNode = currentNode;
            currentNode = currentNode.Next;
            
        }
        
        if (previousNode == null)
        {
            newNode.Next = this.First;
            this.First = newNode;
        }
        else
        {
            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }
        
    }

    public void Print()
    {
        Console.Write("Sequence: ");
        CustomLinkedList? currentNode = this.First;
        while (currentNode != null)
        {
            Console.Write(currentNode.Value);
            if (currentNode.Next != null)
            {
                Console.Write(" -> ");
            }
            currentNode = currentNode.Next;
        }
        
        Console.WriteLine();
    }

    public void PrintReverse(){
        Console.Write("Reversed: ");
        CustomLinkedList? currentNode = this;
        CustomLinkedList? lastNode = null;
        while(currentNode.Next != null){
            currentNode = currentNode.Next;
        }

        lastNode = currentNode;
        while(lastNode != null){
            Console.Write(lastNode.Value);
            if(lastNode.Previous != null){
                Console.Write(" <- ");
            }
            lastNode = lastNode.Previous;
        }

        Console.WriteLine();
    }

}

