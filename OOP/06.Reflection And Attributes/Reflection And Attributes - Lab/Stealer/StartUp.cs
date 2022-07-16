using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string missionResult = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            Console.WriteLine(missionResult);
        }
    }


}
