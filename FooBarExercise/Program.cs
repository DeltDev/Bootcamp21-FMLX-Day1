void Generate(int x)
{
    for (int i = 1; i <= x; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.Write("foobar");
        } else if (i % 3 == 0)
        {
            Console.Write("foo");
        } else if (i % 5 == 0)
        {
            Console.Write("bar");
        }
        else
        {
            Console.Write(i);
        }

        if (i != x)
        {
            Console.Write(", ");
        }
    }
    
    Console.WriteLine();
}
Console.Write("FooBar exercise \nType a number: ");
string? input = Console.ReadLine();
int inputNum = int.Parse(input);
Generate(inputNum);