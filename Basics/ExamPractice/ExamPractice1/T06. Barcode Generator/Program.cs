using System;

namespace T06._Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string num1Converted = num1.ToString();
            string num2Converted = num2.ToString();

            int firstDigitFromNum1 = int.Parse(num1Converted[0].ToString());
            int secondDigitFromNum1 = int.Parse(num1Converted[1].ToString());
            int thirdDigitFromNum1 = int.Parse(num1Converted[2].ToString());
            int fourthDigitFromNum1 = int.Parse(num1Converted[3].ToString());

            int firstDigitFromNum2 = int.Parse(num2Converted[0].ToString());
            int secondDigitFromNum2 = int.Parse(num2Converted[1].ToString());
            int thirdDigitFromNum2 = int.Parse(num2Converted[2].ToString());
            int fourthDigitFromNum2 = int.Parse(num2Converted[3].ToString());

            for (int i = firstDigitFromNum1; i <= firstDigitFromNum2; i++)
            {
                for (int j = secondDigitFromNum1; j <= secondDigitFromNum2; j++)
                {
                    for (int k = thirdDigitFromNum1; k <= thirdDigitFromNum2; k++)
                    {
                        for (int l = fourthDigitFromNum1; l <= fourthDigitFromNum2; l++)
                        {
                            if (i % 2 == 1 && j % 2 == 1 && k % 2 == 1 && l % 2 == 1)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }

        }
    }
}
