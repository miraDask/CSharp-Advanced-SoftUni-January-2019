namespace _01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] locksSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsSequence);
            Queue<int> locks = new Queue<int>(locksSequence);

            int countOfShootedBullets = 1;

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countOfShootedBullets % gunBarrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }

                if (bullets.Any() && locks.Any())
                {
                    countOfShootedBullets++;
                }
            }

            if (!bullets.Any() && locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (!locks.Any())
            {
                int bulletsLeft = bulletsSequence.Length - countOfShootedBullets;
                int moneyEarned = intelligence - (countOfShootedBullets * bulletPrice);

                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
