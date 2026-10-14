//Utility Classes

// Console.WindowWidth = Console.LargestWindowWidth;
// Console.WindowHeight = Console.LargestWindowHeight;
// Console.ForegroundColor = ConsoleColor.Yellow;
// Console.BackgroundColor = ConsoleColor.Green;
// Console.WriteLine("ZA WARUDO!");

// Console.WindowWidth = Console.LargestWindowWidth;
// Console.ForegroundColor = ConsoleColor.Green;
// Console.Write("test... 50%");
// Console.CursorLeft -= 3; // Move cursor back 3 positions
// Console.Write("90%");    // Result: "test... 90%"

using System.Diagnostics;
using System.Numerics;

Console.WriteLine(Environment.CurrentDirectory);
Console.WriteLine(Environment.SystemDirectory);
Console.WriteLine(Environment.CommandLine);

Console.WriteLine(Environment.MachineName);
Console.WriteLine(Environment.ProcessorCount);
Console.WriteLine(Environment.OSVersion);
Console.WriteLine(Environment.NewLine);
Console.WriteLine(Environment.UserName);
Console.WriteLine(Environment.UserInteractive);
Console.WriteLine(Environment.UserDomainName);
Console.WriteLine(Environment.TickCount);
Console.WriteLine(Environment.StackTrace);
Console.WriteLine(Environment.WorkingSet);
Console.WriteLine(Environment.Version);
// Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
// Process.Start(@"C:\Users\akbaraf18\AppData\Local\Programs\Microsoft VS Code\Code.exe");
Console.WriteLine(45.ToString("X"));
Console.WriteLine(45.ToString("B"));
// BigInteger bigInt = BigInteger.Pow(10,100000);
// Console.WriteLine(bigInt.ToString());

for (int i = 0; i < 10; i++)
{
    Random rand = new Random();
    Random rand2 = new Random();
    Console.WriteLine($"{rand.Next(100)} {rand2.Next(100)}");
}