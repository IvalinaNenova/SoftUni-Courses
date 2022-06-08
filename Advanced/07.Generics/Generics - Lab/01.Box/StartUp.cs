using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);
         
        }
    }
}
