//Variables and parameters

//pass by value

using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using Luar.Tengah.Dalam;

//null operators
string s1 = null;
string s2 = s1 ?? "kebab";
Console.WriteLine(s2);

s1 ??= s2;
Console.WriteLine("{0} {1}",s1,s2);

//switch keyword
int cardNumber = 11;
string cardName1 = (cardNumber) switch 
{
    13 => "King",
    12 => "Queen",
    11 => "Jack",
    _ => "usual card"
};

cardNumber = 4;

string cardName2 = (cardNumber) switch 
{
    13 => "King",
    12 => "Queen",
    11 => "Jack",
    _ => "usual card"
};

Console.WriteLine("{0} {1}",cardName1,cardName2);

//namespace
DummyClass.ZaWarudo();

//checked keyword

int a1 = 1000000;
int a2 = 1000000;

unchecked
{
    int c = a1*a2;
    Console.WriteLine(c);
}

// checked
// {
//     int c = a1*a2;
//     Console.WriteLine(c);
// }

//special values in double

Console.WriteLine(double.NegativeInfinity); // -Inf
Console.WriteLine(double.PositiveInfinity); // Inf
Console.WriteLine(double.NegativeZero); // -0

Console.WriteLine(1.0 / 0.0); //Inf
Console.WriteLine(-1.0/0.0); // -Inf

Console.WriteLine(0.0/0.0); //NaN
Console.WriteLine(double.PositiveInfinity - double.PositiveInfinity); //NaN

Console.WriteLine(double.NegativeInfinity + double.NegativeInfinity); //-Inf
Console.WriteLine(double.PositiveInfinity + double.PositiveInfinity); // Inf
Console.WriteLine(double.NegativeInfinity + double.PositiveInfinity); //NaN

Console.WriteLine(double.NaN == double.NaN); 
//kalo mau cek apakah number ini NaN atau bukan, 
//cara ini salah karena di C# NaN selalu berbeda dengan NaN lain
Console.WriteLine(double.IsNaN(0.0/0.0)); //cara ini benar untuk membandingkan nilai NaN

//tes untuk decimal karena di atas untuk double
decimal b1 = 0.0M;
decimal b2 = 0.0M;

// unchecked
// {
//     Console.WriteLine(b1/b2); //ini error divide by zero
// }

//check non circuiting operator
bool initState = false; 
bool CheckSecondOperand()
{
    initState = true;
    return true;
}

bool result = false && CheckSecondOperand();

Console.WriteLine("initState (short circuiting): {0}", initState);

result = false & CheckSecondOperand();
Console.WriteLine("initState (non short circuiting): {0}", initState);

initState = true;
bool CheckSecondOperand2()
{
    initState = false;
    return false;
}

result = true || CheckSecondOperand2();
Console.WriteLine("initState (short circuiting): {0}", initState);

result = true | CheckSecondOperand2();
Console.WriteLine("initState (non short circuiting): {0}", initState);

// ways to write strings

// verbatim string vs original string

string uriVerbatim = @"c:\documents\project";
string uriOriginal = "c:\\documents\\project";

Console.WriteLine(uriVerbatim);
Console.WriteLine(uriOriginal);

string escaped = "Hello\r\nworld";
string verbatim = @"Hello
world";

Console.WriteLine(verbatim);
Console.WriteLine(escaped);

// verbatim string vs raw string
string verbatimQuotes = @" ""Za Warudo"" wa Saikyou no Sutando da";
string rawQuotes = """ "Za Warudo" wa Saikyou no Sutando da """;
Console.WriteLine(verbatimQuotes);
Console.WriteLine(rawQuotes);

int x1 = 4;
Console.WriteLine($"A square has {x1} sides");

string s = $"255 in hex is {byte.MaxValue:X2}";
Console.WriteLine(s);

bool b = true;
Console.WriteLine($"The answer in binary is {(b ? 1 : 0)}");

//another way of string interpolation with Console.WriteLine

int i = 1;
int j = 2;
int k = 3;

Console.WriteLine("{0}, {1}, {2}",i,j,k);

// array

void Bar(char[] arr)
{
    Console.WriteLine(arr);
}

Bar(['a','i','u','e','o']);

//indices and ranges
char[] vowels = {'a','i','u','e','o'};

char c1 = vowels[^1];
char c2 = vowels[^3];

Console.WriteLine($"{c1}  {c2}");
char[] c3 = vowels[2..4];
char[] c4 = vowels[^3..];

Console.WriteLine(c3);
Console.WriteLine(c4);

//rectangular arrays (jumlah kolomnya harus sama di setiap baris)
int[,] recArray = new int[,]
{
    {1,2,3},
    {4,5,6},
    // {7,8,9,10},
    {7,8,9}
};

//jagged arrays (boleh berbeda)
int [][] jagArray = new int[][]
{
    new int[] {1,2,3},
    new int[] {4,5,6},
    new int[] {7,8,9,10},
};

int x = 8;
Console.WriteLine("pass by value");
Console.WriteLine("sebelum: {0}", x);
Foo(x);
Console.WriteLine("sesudah: {0}",x);
static void Foo(int x)
{
    x = x *78;
    Console.WriteLine("di dalam fungsi: {0}",x);
}

//pass by reference
Console.WriteLine("pass by reference (ref)");
x = 8;

Console.WriteLine("sebelum: {0}", x);
Foo2(ref x);

Console.WriteLine("sesudah: {0}",x);
static void Foo2(ref int x)
{
    x = x *78;
    Console.WriteLine("di dalam fungsi: {0}",x);
}

x = 8;
int y,z,a;
y = 81;
z = 800;
a = 69;
Foo3(out y,out z,out _);
static void Foo3(out int y, out int z, out int a)
{
    z = 70;
    y = 22;
    a = 90;
}

//perbedaan ref vs out di C#endregion

int y2;
static void Foo4(out int x)
{
    x = 78;
    Console.WriteLine("di dalam fungsi: {0}",x);
}
static void Foo5(ref int x)
{
    x = 78;
    Console.WriteLine("di dalam fungsi: {0}",x);
}

static void Foo6(in int x)
{
    // x = 69; //ini tidak bisa karena in tidak membolehkan perubahan nilai
}
// Foo5(ref y2); //tidak bisa, kalau fungsinya ref variabelnya harus diinisialisasi dulu
Foo4(out y2); //ini bisa tanpa diperlukan inisialisasi variabel masuk
Console.WriteLine("{0} {1} {2}",y,z,a);

//params
int total = Sum(1, 2, 3, 4); //params bisa mengubah pemanggilan fungsi seperti ini menjadi array
Console.WriteLine(total);   

int total2 = Sum(new int[] { 1, 2, 3, 4 });

int Sum(params int[] ints) 
{
    int sum = 0;
    for (int i = 0; i < ints.Length; i++)
        sum += ints[i];
    return sum;
}

y = 5 * (x = 2);

Console.WriteLine(y);