using QueueExerciseWeek4;

CustomStringQueuePriorityWeek4 queue = new CustomStringQueuePriorityWeek4();

queue.AddRule("urgent",10);
queue.AddRule("normal", 5);

queue.Enqueue("normal");
queue.Enqueue("urgent");
queue.Enqueue("tidak penting");

queue.Process();