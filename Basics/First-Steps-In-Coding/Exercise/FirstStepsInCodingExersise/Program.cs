using System;

namespace FirstStepsInCodingExersise
{
    class Program
    {
        static void Main(string[] args)
        {
            //: 1 USD = 1.79549 BGN.

            double USD = double.Parse(Console.ReadLine());
            double BGN = USD * 1.79549;

            Console.WriteLine(BGN);
        }
    }
}
