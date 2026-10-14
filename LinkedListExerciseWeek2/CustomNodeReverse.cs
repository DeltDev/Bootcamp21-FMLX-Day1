namespace LinkedListExercise;

internal class CustomNodeReverse
{
    public int? Value { get; set; }
    public CustomNodeReverse? Next { get; set; }
    public CustomNodeReverse? Previous {get; set;}
    public CustomNodeReverse()
    {
        this.Value = null;
        this.Next = null;
        this.Previous = null;
    }
    public CustomNodeReverse(int value, CustomNodeReverse? previous)
    {
        this.Value = value;
        this.Next = null;
        this.Previous = previous;
    }

    public CustomNodeReverse(int value){
        this.Value = value;
        this.Next = null;
        this.Previous = null;
    }

    public void Append(int value)
    {
        Console.WriteLine($"Appended {value}");
        if (this.Value == null)
        {
            this.Value = value;
            return;
        }
        CustomNodeReverse newNode = new CustomNodeReverse(value);
        CustomNodeReverse currentNode = this;

        while (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }
        
        currentNode.Next = newNode;
        newNode.Previous = currentNode;

        //1->2->3
        //1<-2<-3
        //append 4
        //
    }

    public void Print()
    {
        Console.Write("Sequence: ");
        CustomNodeReverse? currentNode = this;
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
        CustomNodeReverse? currentNode = this;
        CustomNodeReverse? lastNode = null;
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

