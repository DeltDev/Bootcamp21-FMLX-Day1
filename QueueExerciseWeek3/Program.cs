using QueueExercise;

CustomStringQueuePriority customStringQueuePriority = new CustomStringQueuePriority();

customStringQueuePriority.Enqueue("A",1);
customStringQueuePriority.Enqueue("B",5);
customStringQueuePriority.Enqueue("C",6);
customStringQueuePriority.Process();
customStringQueuePriority.Process();