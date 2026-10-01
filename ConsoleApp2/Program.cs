//Variables and parameters

//pass by value

using System.Runtime.CompilerServices;

int x = 8;
Console.WriteLine(x);
Foo(x);
Console.WriteLine(x);
static void Foo(int x)
{
    x = x *78;
    Console.WriteLine(x);
}

//pass by reference
x = 8;
Console.WriteLine(x);
Foo2(ref x);
Console.WriteLine(x);
static void Foo2(ref int x)
{
    x = x *78;
    Console.WriteLine(x);
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

Console.WriteLine("{0} {1} {2}",y,z,a);
