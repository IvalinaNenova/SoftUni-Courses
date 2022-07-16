namespace Stealer
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.RevealPrivateMethods("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
