
using MulticastExercise;

//Action multicast
Action<int> ReportProgress;

void WriteProgressToConsole(int percentComplete) => Console.WriteLine($"Console: {percentComplete}%");
void WriteProgressToConsole2(int percentComplete) => Console.WriteLine($"Another Console: {percentComplete}%");
void WriteProgressToFile(int percentComplete) => File.WriteAllText("progress.txt", percentComplete.ToString());

ReportProgress = WriteProgressToConsole;
ReportProgress += WriteProgressToFile;
ReportProgress += WriteProgressToConsole2;
Util.HeavyWork(ReportProgress);

//Func multicast(???) 

Func<int, int, int> MultiCalculation;

int Add(int x, int y) => x + y;
int Subtract(int x, int y) => x - y;
int Multiply(int x, int y) => x * y;

MultiCalculation = Add;
MultiCalculation += Subtract;
MultiCalculation += Multiply;

Util.HeavyCalculation(MultiCalculation);

// public class Util
// {
//     public static void HeavyWork(Action<int> progress)
//     {
//         for (int i = 0; i <= 10; i++)
//         {
//             progress(i * 10);
//             System.Threading.Thread.Sleep(5000);
//         }
//     }
//
//     public static void HeavyCalculation(Func<int, int, int> multiCalculation)
//     {
//         int result = multiCalculation(8, 5);
//         Console.WriteLine(result);
//     }
// }

