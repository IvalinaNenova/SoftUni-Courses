using System;

namespace T04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = true;

            if (HasInvalidLength(password))
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (HasInvalidSymbols(password))
            {
                isValid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!HasEnoughDigits(password, 2))
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
        public static bool HasEnoughDigits(string password, int count)
        {
            int digitCounter = 0;

            foreach (var symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCounter++;

                    if (digitCounter == count)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private static bool HasInvalidSymbols(string password)
        {
            foreach (var symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasInvalidLength(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return false;
            }

            return true;
            
        }
    }
}
