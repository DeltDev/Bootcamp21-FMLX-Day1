using StackExercise;

CustomStringStackRedo stack = new(new CustomStringStackRedo());

stack.Type("A");
stack.Type("B");
stack.Undo();
stack.Redo();
stack.Undo();
stack.Type("C");
stack.Redo();