namespace DelegateCompatibility;

internal class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("I'm an animal in general");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof I'm a Dog");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow I'm a cat");
    }
}

class Puppy : Dog
{
    public sealed override void MakeSound()
    {
        Console.WriteLine("Woof I'm a puppy, a descendant of a dog");
    }
}

struct Point
{
    public int X;
    public int Y;

}