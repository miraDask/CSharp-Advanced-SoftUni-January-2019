namespace _02.CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int biggestNumSequence = 1;

            for (int numIndex = 0; numIndex < numbers.Count; numIndex++)    // loop through every number
            {

                for (int step = 1; step < numbers.Count; step++)   // loop through steps
                {

                    int sequenceCount = 1;
                    int currentNumberIndex = numIndex;
                    int indexDiff = numbers.Count - currentNumberIndex;
                    int nextNumberIndex = GetNext(step, currentNumberIndex, indexDiff);
                    int nextNumber = numbers[nextNumberIndex];

                    while (numbers[nextNumberIndex] > numbers[currentNumberIndex])
                    {
                        currentNumberIndex = nextNumberIndex;
                        indexDiff = numbers.Count - currentNumberIndex;
                        nextNumberIndex = GetNext(step, currentNumberIndex, indexDiff);
                        sequenceCount++;
                    }

                    if (sequenceCount > biggestNumSequence)
                    {
                        biggestNumSequence = sequenceCount;
                    }
                }
            }

            Console.WriteLine(biggestNumSequence);
        }

        private static int GetNext(int step, int currentNumberIndex, int indexDiff)
        {
            int nextNumberIndex = -1;

            if (step >= indexDiff)
            {
                nextNumberIndex = step - indexDiff;
            }
            else
            {
                nextNumberIndex = currentNumberIndex + step;
            }

            return nextNumberIndex;
        }
    }
}
