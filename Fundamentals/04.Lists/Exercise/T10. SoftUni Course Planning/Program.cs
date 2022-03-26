using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> carriculum = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                List<string> command = input.Split(":").ToList();

                string action = command[0];
                string lessonTitle1 = command[1];

                if (action == "Add" && !carriculum.Contains(lessonTitle1))
                {
                    carriculum.Add(lessonTitle1);
                }
                else if (action == "Insert" && !carriculum.Contains(lessonTitle1))
                {
                    int index = int.Parse(command[2]);
                    carriculum.Insert(index, lessonTitle1);
                }
                else if (action == "Remove" && carriculum.Contains(lessonTitle1))
                {
                    carriculum.Remove(lessonTitle1);
                    carriculum.Remove(lessonTitle1 + "-Exercise");
                }
                else if (action == "Exercise")
                {
                    if (carriculum.Contains(lessonTitle1) && !carriculum.Contains(lessonTitle1 + "-Exercise"))
                    {
                        int index = carriculum.IndexOf(lessonTitle1) + 1;
                        carriculum.Insert(index, lessonTitle1 + "-Exercise");
                    }
                    else if (!carriculum.Contains(lessonTitle1))
                    {
                        carriculum.Add(lessonTitle1);
                        carriculum.Add(lessonTitle1 + "-Exercise");
                    }
                }
                else if (action == "Swap")
                {
                    string lessonTitle2 = command[2];

                    if (carriculum.Contains(lessonTitle1) && carriculum.Contains(lessonTitle2))
                    {
                        int firstIndex = carriculum.IndexOf(lessonTitle1);
                        int secondIndex = carriculum.IndexOf(lessonTitle2);
                        carriculum[firstIndex] = lessonTitle2;
                        carriculum[secondIndex] = lessonTitle1;

                        if (carriculum.Contains($"{lessonTitle1}-Exercise"))
                        {
                            carriculum.Remove($"{lessonTitle1}-Exercise");
                            carriculum.Insert(secondIndex + 1, $"{lessonTitle1}-Exercise");
                        }

                        if (carriculum.Contains($"{lessonTitle2}-Exercise"))
                        {
                            carriculum.Remove($"{lessonTitle2}-Exercise");
                            carriculum.Insert(firstIndex + 1, $"{lessonTitle2}-Exercise");
                        }
                    }
                }
            }

            for (int i = 0; i < carriculum.Count; i++)
            {
                Console.Write($"{i + 1}.{carriculum[i]}\n");
            }


        }
    }
}
