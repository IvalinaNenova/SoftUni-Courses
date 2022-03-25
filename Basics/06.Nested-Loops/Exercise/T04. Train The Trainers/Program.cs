using System;

namespace T04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int JouryNumber = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double sumOfAllGrades = 0;
            double numberOfTotalGrades = 0;


            while (presentation != "Finish")
            {
                double sumOfGradesPerPresentation = 0;
                int numberOfGradesPerPresentation = 0;
                for (int i = 1; i <= JouryNumber; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    numberOfTotalGrades++;
                    sumOfGradesPerPresentation += grade;
                    numberOfGradesPerPresentation++;
                    if (numberOfGradesPerPresentation==JouryNumber)
                    {
                    Console.WriteLine($"{presentation} - {sumOfGradesPerPresentation / JouryNumber:f2}.");
                    }

                    sumOfAllGrades += grade;

                }
                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {sumOfAllGrades / numberOfTotalGrades:f2}.");

        }
    }
}
