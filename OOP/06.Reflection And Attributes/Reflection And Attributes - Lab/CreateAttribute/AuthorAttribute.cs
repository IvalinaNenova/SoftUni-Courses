using System;
namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
