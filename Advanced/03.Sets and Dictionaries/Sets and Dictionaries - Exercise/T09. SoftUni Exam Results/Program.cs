using System;
using System.Collections.Generic;
using System.Linq;

namespace T09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var statistics = new SortedDictionary<string, int>();
            var studentResults = new SortedDictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] data = input.Split('-');
                string username = data[0];
                string language = data[1];

                if (language != "banned")
                {
                    int points = int.Parse(data[2]);
                    if (!studentResults.ContainsKey(username))
                    {
                        studentResults[username] = points;

                    }
                    else if (studentResults[username] < points)
                    {
                        studentResults[username] = points;
                    }

                    if (!statistics.ContainsKey(language))
                    {
                        statistics[language] = 0;
                    }

                    statistics[language]++;

                }
                else
                {
                    if (studentResults.ContainsKey(username))
                    {
                        studentResults.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }

            var ordered = studentResults.OrderByDescending(user => user.Value);

            Console.WriteLine("Results:");
            if (ordered.Any())
            {
                foreach (var (student, points) in ordered)
                {
                    Console.WriteLine($"{student} | {points}");
                }
            }

            Console.WriteLine("Submissions:");
            foreach (var (language, entries) in statistics.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language} - {entries}");
            }
        }
    }
}
