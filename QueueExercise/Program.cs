//Implementasi di bawah menggunakan built in Collection Queue<T>

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

Enqueue("A");
Enqueue("B");
Process();
Process();
Process();