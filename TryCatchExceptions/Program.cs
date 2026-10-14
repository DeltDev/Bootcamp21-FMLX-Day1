int Calc(int x) => 10/x;

try
{
    int x = Calc(0);
    Console.WriteLine(x);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("This code will execute even if the exception didn't get caught"); 
    //semua code yang ada di blok finally akan jalan meskipun exception tidak di catch
}

Console.WriteLine("Program Completed"); //ini tidak akan jalan jika exception tidak dicatch
int? i = 5;
Console.WriteLine(i);

int j = 6;
int? nullableJ = j;

int? nullableK = 69;
int k = (int)nullableK;

object o = "string";

int? o2 = o as int?;
Console.WriteLine(o2.HasValue);


