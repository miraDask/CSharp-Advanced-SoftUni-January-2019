using System;
using System.Collections.Generic;
using System.Linq;

class KeyRevolver
{
    static void Main()
    {
        int priceOfBullets = int.Parse(Console.ReadLine());
        int sizeOfGunBarrel = int.Parse(Console.ReadLine());
        int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int intelligenceValue = int.Parse(Console.ReadLine());

        Stack<int> bulletsStack = new Stack<int>(bullets);
        Queue<int> locksQueue = new Queue<int>(locks);

        int bulletsCount = 0;


        while (bulletsStack.Any() && locksQueue.Any())
        {

            int currentBulletPower = bulletsStack.Pop();
            bulletsCount++;
            int currentLockPower = locksQueue.Peek();

            if (currentBulletPower <= currentLockPower)
            {
                Console.WriteLine("Bang!");
                locksQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");

            }
            

            if (bulletsCount % sizeOfGunBarrel == 0 && bulletsStack.Any())
            {
                Console.WriteLine("Reloading!");
            }

        }

        if (locksQueue.Any())
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
        }
        else if (bulletsStack.Any() || bulletsStack.Any() == false && locksQueue.Any() == false)
        {

            int earnedMoney = intelligenceValue - (bulletsCount * priceOfBullets);

            Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${earnedMoney}");
        }
    }
}

