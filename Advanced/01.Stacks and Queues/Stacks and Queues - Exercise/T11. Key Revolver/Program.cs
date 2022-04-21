using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locksArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());
            int currentBulletsInBarel = sizeOfBarrel;

            Queue<int> locks = new Queue<int>(locksArray);
            Stack<int> bullets = new Stack<int>(bulletsArray);

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Pop();
                currentBulletsInBarel--;
                
                if (currentBullet <= locks.Peek() )
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentBulletsInBarel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentBulletsInBarel = sizeOfBarrel;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int bulletsUsed = bulletsArray.Length - bullets.Count;
                int deduction = bulletsUsed * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - deduction}");
            }
        }
    }
}
