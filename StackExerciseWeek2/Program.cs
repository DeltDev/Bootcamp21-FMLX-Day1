using StackExercise;

Console.WriteLine("Stack (menggunakan class custom CustomStringStack)");
CustomStringStackDrop customStringStack = new CustomStringStackDrop();

customStringStack.Type("A");
customStringStack.Type("B");
customStringStack.Type("C");
customStringStack.Type("D");
customStringStack.Undo();
customStringStack.Undo();
customStringStack.Undo();
customStringStack.Undo();