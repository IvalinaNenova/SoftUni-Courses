using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList {"Iva", "Marina", "Pesho", "Gosho", "Svetoslav"};
            string random = list.RandomString();
            Console.WriteLine(random);
        }
    }
}
