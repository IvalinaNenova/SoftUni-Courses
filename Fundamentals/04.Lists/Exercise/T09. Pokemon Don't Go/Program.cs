using System;
using System.Collections.Generic;
using System.Linq;

namespace T09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sumOfPokemons = 0;

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int pokemonPower = 0;

                if (index < 0)
                {
                    index = 0;
                    pokemonPower = numbers[index];
                    numbers.RemoveAt(index);
                    numbers.Insert(0, numbers[numbers.Count - 1]);

                }
                else if (index > numbers.Count - 1)
                {
                    index = numbers.Count - 1;
                    pokemonPower = numbers[index];
                    numbers.RemoveAt(index);
                    numbers.Insert(index, numbers[0]);
                }
                else
                {
                    pokemonPower = numbers[index];
                    numbers.RemoveAt(index);
                }

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= pokemonPower)
                    {
                        numbers[i] += pokemonPower;
                    }
                    else if (numbers[i] > pokemonPower)
                    {
                        numbers[i] -= pokemonPower;
                    }
                }
                sumOfPokemons += pokemonPower;

            }
            Console.WriteLine(sumOfPokemons);
        }

    }
}
