using CollectionHierarchy.Classes;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddAndRemoveCollection addAndRemoveCollection = new AddAndRemoveCollection();
            MyList myList = new MyList();

            List<int> addResult1 = new List<int>();
            List<int> addResult2 = new List<int>();
            List<int> addResult3 = new List<int>();

            string[] items = Console.ReadLine().Split();

            foreach (var item in items)
            {
                addResult1.Add(addCollection.Add(item));
                addResult2.Add(addAndRemoveCollection.Add(item));
                addResult3.Add(myList.Add(item));
            }

            List<string> removeResult1 = new List<string>();
            List<string> removeResult2 = new List<string>();

            int itemsToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsToRemove; i++)
            {
                removeResult1.Add(addAndRemoveCollection.Remove());
                removeResult2.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addResult1));
            Console.WriteLine(string.Join(' ', addResult2));
            Console.WriteLine(string.Join(' ', addResult3));
            Console.WriteLine(string.Join(' ', removeResult1));
            Console.WriteLine(string.Join(' ', removeResult2));
        }
    }
}
