using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();
        }
    }
}
