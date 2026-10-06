//Class Basics

using System.Runtime.InteropServices.Marshalling;

Test.Method1();

Rectangle rect = new Rectangle(3,4);
Rectangle rect2 = new Rectangle { Width = 8, Height = 9 };
(float width, float height) = rect;
Console.WriteLine(width + "," + height);
(width, height) = rect2;
Console.WriteLine(width + "," + height);

Console.WriteLine(rect.Width + "," + rect.Height);
Stock msft = new();
msft.CurrentPrice = 30;
msft.SharesOwned = 8;
Console.WriteLine(msft.CurrentPrice);
Console.WriteLine(msft.Worth);

Note note = new Note { Pitch = 30 };
//note.Pitch = 300;

Sentence s = new();
Console.WriteLine(s[5]);

foreach (string w in s.Words)
{
    Console.WriteLine(w);
}

s[2] = "Red";

foreach (string w in s.Words)
{
    Console.WriteLine(w);
}

StaticConstructorClass c =  new StaticConstructorClass();

//Inheritance

Cat tasque = new Cat();
tasque.Name = "Tasque";
tasque.MakeSound();
Animal animal1 = tasque;
animal1.MakeSound();

Dog tobyFox = new Dog();
tobyFox.Name = "Toby Fox";
tobyFox.MakeSound();
Animal animal2 = tobyFox;
animal2.MakeSound();


NameDisplayer.DisplayName(tasque);
NameDisplayer.DisplayName(tobyFox);

Cat tasque2 = (Cat)animal1;

tasque2.MakeSound();
NameDisplayer.DisplayName(tasque2);
//
// Cat tasque3 = (Cat)animal2;
// tasque3.MakeSound();
// DisplayName(tasque3);


Animal animal3 = new Cat();
Animal animal4 = new Dog();
if (animal3 is Cat)
{
    Console.WriteLine("animal3 is Cat");
    animal3.MakeSound();
}

if (animal4 is Cat)
{
    Console.WriteLine("animal4 is Cat");
    animal4.MakeSound();
}
else
{
    Console.WriteLine("animal4 is Dog");
}

NameDisplayer.DisplayName(animal3);
NameDisplayer.DisplayName((dynamic) animal3);
internal static class Test
{
    public static void Method1()
    {
        Console.WriteLine("Method1");
    }
}

class Rectangle
{
    public float Width, Height;

    public Rectangle()
    {
    }

    public Rectangle(float width, float height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void Deconstruct(out float width, out float height)
    {
        width = this.Width;
        height = this.Height;
    }
}

public class Stock
{
    decimal currentPrice,sharesOwned; //ini field

    public decimal CurrentPrice //ini properties
    {
        get { return currentPrice; } 
        set { currentPrice = value; } 
    }

    public decimal Worth
    {
        get { return currentPrice * sharesOwned; }
    }

    public decimal SharesOwned
    {
        get { return sharesOwned; }
        set { sharesOwned = value; }
    }
}

public class Note
{
    public int Pitch { get; init; } = 50;
}

class Sentence
{
    
    string[] words = "The Quick Brown Fox Jumps Over The Lazy Dog".Split();

    public string this[int wordNum]
    {
        get { return words[wordNum]; }
        set { words[wordNum] = value; }
    }

    public string[] Words
    {
        get { return words; }
    }
    
}

class StaticConstructorClass
{
    static StaticConstructorClass()
    {
        Console.WriteLine("This is StaticConstructorClass");
    }
}

//Inheritance

abstract class Animal
{
    public string Name {get; set;}
    public virtual void MakeSound()
    {
        Console.WriteLine("This is animal");
    }
}

abstract class Plant
{
    public abstract void Photosynthesis();
}

class Cat : Animal
{
    
    public sealed override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

class Dog : Animal
{
    public new void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}


class NameDisplayer
{
    public static void DisplayName(Animal animal)
    {
        Console.WriteLine(animal.Name + "(Animal)");
    }

    public static void DisplayName(Cat cat)
    {
        Console.WriteLine(cat.Name + "(Cat)");
    }
    
    public static void DisplayName(Dog dog)
    {
        Console.WriteLine(dog.Name + "(Dog)");
    }
}

// class VenusTrap : Animal, Plant
// {
//     
// }