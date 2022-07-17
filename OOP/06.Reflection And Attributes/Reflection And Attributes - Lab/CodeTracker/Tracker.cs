using System;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes<AuthorAttribute>();

                foreach (AuthorAttribute authorAttribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}
