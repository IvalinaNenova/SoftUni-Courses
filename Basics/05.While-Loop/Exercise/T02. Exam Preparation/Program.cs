using System;

namespace T02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFailedGrades = int.Parse(Console.ReadLine());
            string nameOfProblem = "";
            int numberOfProblems = 0;
            string lastProblem = "";
            double totalFromGrades = 0;
            int timesHeFailed = 0;
            bool isFailed = true;

            while (timesHeFailed < numberOfFailedGrades)
            {
                lastProblem = nameOfProblem;
                nameOfProblem = Console.ReadLine();

                if (nameOfProblem == "Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                totalFromGrades += grade;

                if (grade <= 4)
                {
                    timesHeFailed++;
                }
                numberOfProblems++;
            }

            if (isFailed)
            {
                Console.WriteLine($"You need a break, {numberOfFailedGrades} poor grades.");
            }
            else
            {
                double averageGrade = totalFromGrades / numberOfProblems;
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }

            //while (timesHeFailed < numberOfFailedGrades)
            //{
            //    string lastProblem = nameOfProblem;
            //    nameOfProblem = Console.ReadLine();

            //    if (nameOfProblem == "Enough")
            //    {
            //        double averageGrade = totalFromGrades / numberOfProblems;
            //        Console.WriteLine($"Average score: {averageGrade:f2}");
            //        Console.WriteLine($"Number of problems: {numberOfProblems}");
            //        Console.WriteLine($"Last problem: {lastProblem}");
            //        break;

            //    }
            //    int grade = int.Parse(Console.ReadLine());
            //    totalFromGrades += grade;
            //    if (grade <= 4)
            //    {
            //        timesHeFailed++;
            //        if (timesHeFailed == numberOfFailedGrades)
            //        {

            //            Console.WriteLine($"You need a break, {numberOfFailedGrades} poor grades.");
            //        }
            //    }
            //    numberOfProblems++;
            //}
        }
    }
}
