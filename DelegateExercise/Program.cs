//1. Declare a custom delegate type that takes two integers and returns an integer.
//Write two matching methods (add and multiply), assign each to a delegate variable in turn, and invoke it.

using DelegateExercise;

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

//6. Make a class with one instance method and one static method of the same signature.
//Assign both to delegates, then inspect each delegate's Target and Method properties.
//Explain what Target contains for the static one and why.

OperationClass opClass = new OperationClass();
OperationClass opClass2 = new OperationClass();
Func<int, int, int> opClassInstance = opClass.InstanceAdd;
Func<int, int, int> opClassInstance2 = opClass2.InstanceAdd;
Func<int, int, int> opClassStatic = OperationClass.StaticAdd;
Console.WriteLine($"Instance: {opClassInstance.Invoke(1, 2)} Target: {opClassInstance.Target}");
Console.WriteLine($"Instance 2: {opClassInstance2.Invoke(1, 2)} Target: {opClassInstance2.Target}");
Console.WriteLine($"{opClassInstance == opClassInstance2}");
Console.WriteLine($"Static: {opClassStatic.Invoke(1, 2)} Target: {opClassStatic.Target}");

//7. Create two instances of a class that keeps an internal counter.
//Bind a delegate to each instance's method, call them in an interleaved order,
//and show that each delegate affects only its own object's state.

InternalCounter counter1 = new InternalCounter();
InternalCounter counter2 = new InternalCounter();
CounterTest counterTest = counter1.IncrementCounter;
CounterTest counterTest2 = counter2.IncrementCounter;
counterTest();
counterTest2();
counterTest();
counterTest();
Console.WriteLine($"{counter1.Counter} / {counter2.Counter}");
Console.WriteLine(ReferenceEquals(counterTest.Target, counter1));

//8. Assign the same method to two delegate variables, once by method group and once by wrapping it in a lambda.
//Predict and then verify whether the two delegates compare as equal, and explain the result.

InternalCounter counter3 = new InternalCounter();
CounterTest counterTest3 = counter3.IncrementCounter;
CounterTest counterTest4 = () => { counter3.IncrementCounter(); };
Console.WriteLine(counterTest3.Target);
Console.WriteLine(counterTest4.Target);

//9. Delegate Calculator
Dictionary<string, Func<double, double, double>> op = new();
op.Add("+", AddDouble);
op.Add("-", SubtractDouble);
op.Add("*", MultiplyDouble);
op.Add("/", DivideDouble);
Console.Write("Input a simple math operation (include spaces for each number and operator): ");
string? calculation = Console.ReadLine();
string[]? items = calculation?.Split(" ").ToArray();
Console.WriteLine(double.TryParse(items?[0], out double number1));
Console.WriteLine(double.TryParse(items?[2], out double number2));
Console.WriteLine(items?[1]);
Console.WriteLine($"Result: {op[items?[1]].Invoke(number1,number2)}");

//12. Combine three handlers into one delegate using +=, invoke it, then remove the middle handler with -=.
//What happens if you remove a handler that was never added?

Func<int, int, int> multicast1 = Add;
multicast1 += Multiply;
multicast1 += Subtract;
multicast1 -= Multiply;
Console.WriteLine(multicast1.Invoke(9,8));
Delegate[] multicastList = multicast1.GetInvocationList();
foreach (var item in multicastList)
{
    Console.WriteLine(item.Method.Name);
}

multicast1 -= XplusYplusX;
multicastList = multicast1.GetInvocationList();
foreach (var item in multicastList)
{
    Console.WriteLine(item.Method.Name);
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

static int XplusYplusX(int x, int y)
{
    return x + y + x;
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

static double AddDouble(double x, double y)
{
    return x + y;
}

static double SubtractDouble(double x, double y)
{
    return x - y;
}

static double MultiplyDouble(double x, double y)
{
    return x * y;
}

static double DivideDouble(double x, double y)
{
    return x / y;
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
delegate void CounterTest();