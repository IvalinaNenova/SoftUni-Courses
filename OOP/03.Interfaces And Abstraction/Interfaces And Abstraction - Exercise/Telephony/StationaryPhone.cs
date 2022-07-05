using System;

namespace Telephony
{
    public class StationaryPhone : ICall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
