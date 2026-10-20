void Generate(int x)
{
    for (int i = 1; i <= x; i++)
    {
        if(i%3 == 0 || i%5==0 || i%7 ==0 || i%4 == 0  || i%9 ==0){
           if(i%3 == 0){
                Console.Write("foo");
            }
            if(i%4 == 0){
                Console.Write("baz");
            }
            if(i%5 == 0){
                Console.Write("bar");
            }
            if(i%7 == 0){
                Console.Write("jazz");
            }
            if(i%9 == 0){
                Console.Write("huzz");
            }
        } else {
            Console.Write(i);
        }

        if (i != x)
        {
            Console.Write(", ");
        }
    }
    
    Console.WriteLine();
}
Console.Write("FooBar exercise Week 3 \nType a number: ");
string? input = Console.ReadLine();
int inputNum = int.Parse(input);
Generate(inputNum);