using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = CreateDictionaryOfAccounts();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ');

                try
                {
                    ValidateData(accounts, commands);
                    ExecuteCommand(accounts, commands);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                input = Console.ReadLine();
            }
        }

        public static void ExecuteCommand(Dictionary<int, double> accounts, string[] commands)
        {
            string action = commands[0];
            int accountNumber = int.Parse(commands[1]);
            double sum = double.Parse(commands[2]);

            switch (action)
            {
                case "Deposit":
                    accounts[accountNumber] += sum;
                    break;
                case "Withdraw":
                    accounts[accountNumber] -= sum;
                    break;
            }

            Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
        }
        private static Dictionary<int, double> CreateDictionaryOfAccounts()
        {
            string[] accounts = Console.ReadLine().Split(',');

            Dictionary<int, double> accountsAndBalances = new Dictionary<int, double>();

            foreach (var account in accounts)
            {
                string[] accountData = account.Split('-');
                int accountNumber = int.Parse(accountData[0]);
                double balance = double.Parse(accountData[1]);

                accountsAndBalances[accountNumber] = balance;
            }

            return accountsAndBalances;
        }

        public static void ValidateData(Dictionary<int, double> accounts, string[] commands)
        {
            string action = commands[0];
            int accountNumber = int.Parse(commands[1]);
            double sum = double.Parse(commands[2]);

            if (action != "Deposit" && action != "Withdraw")
            {
                throw new ArgumentException("Invalid command!");
            }

            if (!accounts.ContainsKey(accountNumber))
            {
                throw new InvalidOperationException("Invalid account!");
            }

            if (action == "Withdraw" && accounts[accountNumber] - sum < 0)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }
        }
    }
}
