using LinkedListExerciseWeek4;


CustomLinkedListWeek4 list = new CustomLinkedListWeek4();
list.Append(31);
list.Append(5);
list.Append(40);
list.Append(10);
list.Append(22);
list.Print();                 

list.AddFilter((x) => x > 20);
list.Print();                

list.AddFilter((x) => x % 2 == 0);
list.Print();                 

list.SetSorting((a, b) => a.CompareTo(b));
list.Sort();
list.Print();                

list.SetSorting((a, b) => b.CompareTo(a));
list.Sort();
list.Print();                 


list.SetSorting((a, b) => Math.Abs(a - 25).CompareTo(Math.Abs(b - 25)));
list.Sort();
list.Print();