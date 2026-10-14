using DefaultNamespace;

MusicalNote noteA = new(3);
Console.WriteLine(noteA);
MusicalNote noteB = new(2);
Console.WriteLine(noteB);
MusicalNote noteC = noteA + noteB;
Console.WriteLine(noteC);
MusicalNote noteD = noteA - noteB;
Console.WriteLine(noteD);
MusicalNote noteE = checked(noteA + noteB);
Console.WriteLine(noteE);
MusicalNote noteF = checked(noteA - noteB);
Console.WriteLine(noteF);
noteC = noteC + 7;
Console.WriteLine(noteC);
noteD = noteD - 4;
Console.WriteLine(noteD);

Console.WriteLine(noteA == noteB + 1);
Console.WriteLine(noteA == noteB);
Console.WriteLine(noteA != noteB);
Console.WriteLine(noteA >= noteB);
Console.WriteLine(noteA > noteB);
Console.WriteLine(noteA < noteB);
Console.WriteLine(noteA <= noteB);

double AinHertz = noteA;
Console.WriteLine(AinHertz);
double A432 = 432.0;
MusicalNote noteA432 = (MusicalNote)A432;
Console.WriteLine(noteA432);
Console.WriteLine((double)noteA432);