//Implementasi di bawah menggunakan built in Collection Queue<T>

using QueueExercise;

Queue<string> collectionQueue = new Queue<string>();

void Enqueue(string text)
{
    collectionQueue.Enqueue(text);
    Console.WriteLine($"Queued {text}");
}

void Process()
{
    if (collectionQueue.Count == 0)
    {
        Console.WriteLine("Queue is empty");
    }
    else
    {
        string text = collectionQueue.Dequeue();
        Console.WriteLine($"Processed {text}");
    }
}

Console.WriteLine("Queue (menggunakan library Collection)");
Enqueue("A");
Enqueue("B");
Process();
Process();
Process();

Console.WriteLine();
//Implementasi di bawah ini menggunakan CustomStringQueue

Console.WriteLine("Queue (menggunakan class custom CustomStringQueue)");
CustomStringQueue customStringQueue = new CustomStringQueue();
customStringQueue.Enqueue("A");
customStringQueue.Enqueue("B");
customStringQueue.Enqueue("C");
customStringQueue.Enqueue("D");
customStringQueue.Enqueue("E");
customStringQueue.Enqueue("F");
customStringQueue.Enqueue("G");
customStringQueue.Enqueue("H");
customStringQueue.Enqueue("I");
customStringQueue.Enqueue("J");
customStringQueue.Enqueue("K");
customStringQueue.Process();
customStringQueue.Process();
customStringQueue.Process();