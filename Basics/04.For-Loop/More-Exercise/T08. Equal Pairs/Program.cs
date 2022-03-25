using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int maxDiff = 0;

        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        // Предишна сума
        int prevSum = num1 + num2;

        // Въртим цикълът до -1 
        // понеже имаме сметка на първата сума извън него по-горе.
        for (int i = 0; i < n - 1; i++)
        {
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());

            // Текуща сума
            int currSum = num1 + num2;

            // Проверяваме дали текущата сума е различна от предишната
            // и ако никога не намерим разлика в двете, означава, че не сме намерили maxDiff, 
            // който си остава 0.
            if (prevSum != currSum)
            {
                int tempDiff = Math.Abs(prevSum - currSum);

                if (tempDiff > maxDiff)
                {
                    maxDiff = tempDiff;
                }
            }

            // Заменяме предишната сума с текущата сума 
            // и така при следващата итерация, текущата вече ще е старата.
            prevSum = currSum;
        }

        // Ако максималната разлика е > 0 
        // означава, че сме намерили такава измежду всички двойки
        // и съответно печатаме най-голямата от тях.
        if (maxDiff > 0)
        {
            Console.WriteLine($"No, maxdiff={maxDiff}");
        }
        // В противен случай печатаме предишната или текущата сума 
        // (няма значение, понеже те са равни)
        else
        {
            Console.WriteLine($"Yes, value={prevSum}");
        }
    }
}