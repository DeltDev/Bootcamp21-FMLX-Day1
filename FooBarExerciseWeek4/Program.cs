
using FooBarExerciseWeek4;


FooBarGenericRule fooBar = new FooBarGenericRule();

fooBar.AddRule(3, "Foo");
fooBar.AddRule(5, "Bar");
fooBar.AddRule(4, "Baz");
fooBar.AddRule(7, "Qux");
fooBar.Evaluate(100);
Console.WriteLine();
fooBar.Generate(100);
