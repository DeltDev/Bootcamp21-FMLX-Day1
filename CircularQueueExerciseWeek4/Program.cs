using CircularQueueExerciseWeek4;

internal class Program
{
    static void Main()
    {
        CircularQueue4 queue = new CircularQueue4();

        queue.Log(10);
        queue.Log(20);
        queue.Log(30);
        queue.Log(40);

        queue.Read();  
        queue.Read();  
        queue.Read();  
        queue.Read();  



        queue.SetCapacity(5);

        queue.Log(1);
        queue.Log(2);
        queue.Log(3);
        queue.Log(4);
        queue.Log(5);
        queue.Log(6); 

        queue.Read(); 
        queue.Read(); 



        queue.SetCapacity(3);
        queue.SetOverwritePolicy(false);

        queue.Log(100);
        queue.Log(200);
        queue.Log(300);
        queue.Log(400); 

        queue.Read(); 
        queue.Log(400); 

        queue.Read(); 
        queue.Read(); 
        queue.Read();


        queue.Log(7);
        queue.Log(8);

        queue.SetCapacity(2); 

        queue.Read();

        queue.Log(50);
        queue.Log(60);
        queue.Read();
        queue.Read(); 
    }
}