using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._The_Party_Reservation
{
    public class Filter
    {
        public Filter(string condition, string target)
        {
            Condition = condition;
            Target = target;
        }
        public string Condition { get; set; }

        public string Target { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();
            HashSet<Filter> filters = GetFilters();
            List<string> filteredNames = FilterNames(filters, names);
            Console.WriteLine(String.Join(' ', names));
        }

        public static HashSet<Filter> GetFilters()
        {
            string input = Console.ReadLine();
            HashSet<Filter> filters = new HashSet<Filter>();

            while (input != "Print")
            {
                string[] commands = input.Split(';');
                string action = commands[0];
                string condition = commands[1];
                string target = commands[2];

                Filter currentFilter = new Filter(condition, target);

                switch (action)
                {
                    case "Add filter":
                        filters.Add(currentFilter);
                        break;
                    case "Remove filter":
                        filters.RemoveWhere(filter =>
                            filter.Condition == condition &&
                            filter.Target == target);
                        break;
                }

                input = Console.ReadLine();
            }
            return filters;
        }
        public static List<string> FilterNames(HashSet<Filter> filters, List<string> names)
        {

            foreach (var filter in filters)
            {
                switch (filter.Condition)
                {
                    case "Starts with":
                        names.RemoveAll(name => name.StartsWith(filter.Target));
                        break;
                    case "Ends with":
                        names.RemoveAll(name => name.EndsWith(filter.Target));
                        break;
                    case "Length":
                        names.RemoveAll(name => name.Length == int.Parse(filter.Target));
                        break;
                    case "Contains":
                        names.RemoveAll(name => name.Contains(filter.Target));
                        break;
                }
            }

            return names;
        }
    }
}

