namespace LinkedListExercise;

public class CustomNode
{
    public int? value { get; set; }
    public CustomNode? next { get; set; }

    public CustomNode()
    {
        this.value = null;
        this.next = null;
    }
    public CustomNode(int value)
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
        CustomNode newNode = new CustomNode(value);
        CustomNode currentNode = this;

        while (currentNode.next != null)
        {
            currentNode = currentNode.next;
        }
        
        currentNode.next = newNode;
    }

    public void Print()
    {
        Console.Write($"Sequence: ");
        CustomNode? currentNode = this;
        while (currentNode != null)
        {
            Console.Write(currentNode.value);
            if (currentNode.next != null)
            {
                Console.Write(" -> ");
            }
            currentNode = currentNode.next;
        }
        
        Console.WriteLine();
    }
}

