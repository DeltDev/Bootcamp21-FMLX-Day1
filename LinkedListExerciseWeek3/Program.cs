using LinkedListExercise;


CustomLinkedList list = new CustomLinkedList();
list.Append(30);
list.Append(5);
list.Append(40);
list.Append(10);
list.Append(20);
list.AddFilter((x) => false); 
list.Print();                 

CustomLinkedList seeded = new CustomLinkedList(100);
seeded.Append(200);
seeded.Append(300);
seeded.AddFilter((x) => false);
seeded.Print();               

list.AddFilter((x) => x > 20);
list.Print();                

list.AddFilter((x) => x % 2 == 0);
list.Print();                 


list.AddFilter((x) => false);
list.SetSorting((a, b) => a.CompareTo(b));
list.Sort();
list.Print();                

list.SetSorting((a, b) => b.CompareTo(a));
list.Sort();
list.Print();                 


list.SetSorting((a, b) => Math.Abs(a - 25).CompareTo(Math.Abs(b - 25)));
list.Sort();
list.Print();                 
