//1. Declare a custom delegate type that takes two integers and returns an integer.
//Write two matching methods (add and multiply), assign each to a delegate variable in turn, and invoke it.

BinaryOperation binaryOperation = Add;
int test = binaryOperation(10, 20);
Console.WriteLine(test);
binaryOperation = Multiply;
test = binaryOperation(10, 20);
Console.WriteLine(test);

//2. [Func] Redo problem 1 without declaring your own delegate type.
// List which parts of the declaration you no longer need.
Func<int, int, int> operation = Add;
test = operation(10, 20);
Console.WriteLine(test);
operation = Multiply;
test = operation(10, 20);
Console.WriteLine(test); 

//3. Create an Action that takes a string and prints a greeting. Invoke it with three different names.
// Then create one with no parameters.

Action<string> nameOperation = Greeting;
nameOperation.Invoke("DIO");
nameOperation.Invoke("Waldo");
nameOperation.Invoke("Jeb");
Action parameterlessName = () => {Console.WriteLine("Hello evernyan");};
Action<string> nameOperation2 = name =>
{
    Console.WriteLine($"Hello {name}!");
};
nameOperation2.Invoke("Noelle");
parameterlessName.Invoke();

//4. Write a method that takes an integer array and a delegate, and returns a new array with the delegate applied to every element.
//Test it with squaring, negation, and a lambda of your own.
PluginBinaryOperation([1,2,3,4,5,6,7,8,9], Square);
PluginBinaryOperation([1,2,3,4,5,6,7,8,9], Negate);
PluginBinaryOperation([1,2,3,4,5,6,7,8,9], x => { return 2 * x + 69;});

//5. Write a filter method that takes a list of integers and a boolean-returning delegate, and returns only the matching items.
//Use it for "even numbers" and "greater than 10".
int[] evenNumbers = NumberFilterer([1,2,3,4,5,6,7,8,9,10,11,12,13], isEven);
foreach (int number in evenNumbers)
{
    Console.WriteLine(number);
}
int[] greaterThan10 = NumberFilterer([1,2,3,4,5,6,7,8,9,10,11,12,13], isGreaterThan10);

foreach (int number in greaterThan10)
{
    Console.WriteLine(number);
}

//FAFO about Func lol
Func<int,int,int> BinaryOperation2 = Add;
Console.WriteLine(BinaryOperation2.Invoke(10, 20));
BinaryOperation2 += Multiply;
Console.WriteLine(BinaryOperation2.Invoke(10, 20));
BinaryOperation2 -= Add;
Console.WriteLine(BinaryOperation2.Invoke(10, 20));
BinaryOperation2 += Subtract;
BinaryOperation2 += Multiply;
BinaryOperation2 -= Multiply;
Console.WriteLine(BinaryOperation2.Invoke(10, 20));

Delegate[] invocationList = BinaryOperation2.GetInvocationList();
foreach (var item in invocationList)
{
    Console.WriteLine(item.Method.Name);
    Console.WriteLine(item.Method.Invoke(item.Target, new object[] { 10, 20 }));
}
// binaryOperation = Cube; tidak bisa, karena parameternya tidak sama dengan deklarasi 

static void Greeting(string name)
{
    Console.WriteLine($"Hello, {name}!");
}
static int Add(int x, int y)
{
    return x + y;
}

static int Multiply(int x, int y)
{
    return x * y;
}

static int Cube(int x)
{
    return x * x * x;
}

static int Subtract(int x, int y)
{
    return x - y;
}

static int Square(int x)
{
    return x * x;
}

static int Negate(int x)
{
    return -x;
}

static bool isEven(int x)
{
    return x % 2 == 0;
}

static bool isGreaterThan10(int x)
{
    return x > 10;
}
static void PluginBinaryOperation(int[] arr, Func<int, int> op)
{
    Console.WriteLine("PluginBinaryOperation: " + op.Method.Name);
    foreach (int x in arr)
    {
        Console.WriteLine(op(x));
    }
}

static int[] NumberFilterer(int[] arr, Func<int, bool> op)
{
    Console.WriteLine("NumberFilterer: " + op.Method.Name);
    return arr.Where(x => op(x)).ToArray();
}
delegate int BinaryOperation(int x, int y);