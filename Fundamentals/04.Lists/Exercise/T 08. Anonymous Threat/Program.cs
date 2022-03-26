using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                List<string> action = command.Split(" ").ToList();

                if (action[0] == "merge")
                {
                    int startIndex = int.Parse(action[1]);
                    int endIndex = int.Parse(action[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex > input.Count - 1)
                    {
                        startIndex = input.Count - 1;
                    }
                    if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    StringBuilder concatenated = new StringBuilder();

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatenated.Append(input[startIndex]);
                        input.RemoveAt(startIndex);
                    }

                    input.Insert(startIndex, concatenated.ToString());
                }

                else if (action[0] == "divide")
                {
                    int index = int.Parse(action[1]);
                    int partitions = int.Parse(action[2]);

                    string element = input[index];
                    int lenghtOfSubelements = element.Length / partitions;

                    List<string> result = new List<string>();

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            result.Add(element.Substring(i * lenghtOfSubelements));
                        }
                        else
                        {
                            result.Add(element.Substring(i * lenghtOfSubelements, lenghtOfSubelements));
                        }
                    }
                    input.RemoveAt(index);
                    input.InsertRange(index, result);

                }
            }

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
