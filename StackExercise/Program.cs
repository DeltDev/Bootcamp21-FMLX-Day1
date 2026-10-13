//Implementasi di bawah inimenggunakan Stack<T> dari Collection

using StackExercise;

Stack<string> collectionStack = new Stack<string>();

void Type(string word)
{
    collectionStack.Push(word);
    Console.WriteLine($"Typed {word}");
}

void Undo()
{
    if (collectionStack.Count == 0)
    {
        Console.WriteLine("Stack is empty");
        return;
    }
    string topWord = collectionStack.Pop();
    Console.WriteLine($"Undid {topWord}");
}

Console.WriteLine("Stack (menggunakan library Collection)");
Type("foo");
Type("bar");
Undo();
Undo();
Undo();

//Implementasi di bawah ini menggunakan CustomStringStack

Console.WriteLine("Stack (menggunakan class custom CustomStringStack)");
CustomStringStack customStringStack = new CustomStringStack();

customStringStack.Type("foo");
customStringStack.Type("bar");
customStringStack.Type("foo");
customStringStack.Type("bar");
customStringStack.Type("foo");
customStringStack.Type("bar");
customStringStack.Type("foo");
customStringStack.Type("bar");
customStringStack.Type("foo");
customStringStack.Type("bar");
customStringStack.Undo();
customStringStack.Undo();
customStringStack.Undo();