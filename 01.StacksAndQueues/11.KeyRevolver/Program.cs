using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int mag = int.Parse(Console.ReadLine());

            int[] inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(inputBullets);

            int[] inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(inputLocks);

            int prizeMoney = int.Parse(Console.ReadLine());

            int currentMag = 0;
            int bulletsShot = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                currentMag++;
                bulletsShot++;

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentMag == mag && bullets.Count>0)
                {
                    currentMag = 0;
                    Console.WriteLine("Reloading!");
                }

            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${prizeMoney-(priceOfBullet*bulletsShot)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
