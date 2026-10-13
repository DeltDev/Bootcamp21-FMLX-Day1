using DelegateCompatibility;

void Method1(){};
void DoSomething(object o) => Console.WriteLine(o);
void AnimalSound(Animal a) => a.MakeSound();
void CatSound(Cat c) => c.MakeSound();
void DogSound(Dog d) => d.MakeSound();
void PuppySound(Puppy p) => p.MakeSound();

string GetString() => "Halo";
Animal GetAnimal() => new Animal();
Cat GetCat() => new Cat();
Dog GetDog() => new Dog();
Puppy GetPuppy() => new Puppy();

D1 d1 = Method1;
// D2 d2 = d1;
D2 d2 = new D2(d1);

//Contravariance 1
StringAction sa = DoSomething;
Action<string> act = DoSomething;
sa("Hello World");
act("Hello World");

//Covariance 1
ObjectRetriever or = GetString;
Func<object> orFunc = GetString;
object result = or();

Console.WriteLine(result);
Console.WriteLine(orFunc.Invoke());

//Contravariance Test
Animal animal = new Animal();
Cat cat = new Cat();
Dog dog = new Dog();
Puppy puppy = new Puppy();
Action<Animal> animalAction = AnimalSound;
Action<Cat> catAction = CatSound;
Action<Dog> dogAction = DogSound;
Action<Puppy> puppyAction = PuppySound;

//Parameter delegate = animal

animalAction(animal);
animalAction(dog);
animalAction(cat);
animalAction(puppy);

//Parameter delegate = Cat
// catAction(animal); //doesn't compile
catAction(cat);
// catAction(dog); //doesn't compile
// catAction(puppy); //doesn't compile

//Parameter delegate = Dog
// dogAction(animal); //doesn't compile
// dogAction(cat); //doesn't compile
dogAction(dog);
dogAction(puppy);

//Parameter delegate = Puppy
// puppyAction(animal); //doesn't compile
// puppyAction(cat); //doesn't compile
// puppyAction(dog); //doesn't compile
puppyAction(puppy);


//Covariance Test
Func<Animal> animalFunc = GetAnimal;
Func<Cat> catFunc = GetCat;
Func<Dog> dogFunc = GetDog;
Func<Puppy> puppyFunc = GetPuppy;

//Return Method = Animal
Animal result1 = animalFunc();
Animal result2 = catFunc();
Animal result3 = puppyFunc();
Animal result4 = dogFunc();

//Return Method = Cat
// Cat result5 = animalFunc(); //doesn't compile
Cat result6 = catFunc();
// Cat result7 = dogFunc(); //doesn't compile
// Cat result8 = puppyFunc(); //doesn't compile

//Return Method = Dog
// Dog result9 = animalFunc(); //doesn't compile
// Dog result10 = catFunc(); //doesn't compile
Dog result11 = dogFunc();
Dog result12 = puppyFunc();

//Return Method = Puppy
// Puppy result13 = animalFunc(); //doesn't compile
// Puppy result14 = catFunc(); //doesn't compile
// Puppy result15 = dogFunc(); //doesn't compile
Puppy result16 = puppyFunc();
delegate void D1();
delegate void D2();
delegate void StringAction(string s); //Contravariance:
                                      //Berhasil compile jika dan hanya jika PARAMETER delegate lebih spesfik atau sama dengan PARAMETER method
delegate object ObjectRetriever(); //Covariance:
                                   //Berhasil compile jika dan hanya jika RETURN METHOD lebih spesifik dari atau sama dengan RETURN DELEGATE