namespace p01.Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] leftSocksSeq = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] rightSockSeq = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> leftSocks = new Stack<int>(leftSocksSeq);
            Queue<int> rightSocks = new Queue<int>(rightSockSeq);

            List<int> pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentLeftValue = leftSocks.Peek();
                int currentRightValue = rightSocks.Peek();

                if (currentLeftValue > currentRightValue)
                {
                    int pairvalue = currentLeftValue + currentRightValue;
                    pairs.Add(pairvalue);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (currentLeftValue < currentRightValue)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();
                    int temp = leftSocks.Pop();
                    temp++;
                    leftSocks.Push(temp);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}

