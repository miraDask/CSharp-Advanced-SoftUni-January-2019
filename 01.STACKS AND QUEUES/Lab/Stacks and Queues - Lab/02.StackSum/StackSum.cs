using System;
using System.Collections.Generic;
using System.Linq;

class StackSum
{
    static void Main()
    {

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Stack<int> stackOfNumbers = new Stack<int>(numbers);

        string input = Console.ReadLine().ToLower();


        while (input != "end")
        {
            string[] data = input.Split();

            string command = data[0];

            if (command == "add")
            {
                
                int firstNumber = int.Parse(data[1]);
                int secondNumber = int.Parse(data[2]);

                stackOfNumbers.Push(firstNumber);
                stackOfNumbers.Push(secondNumber);
            }
            else
            {
                int countOfNumbersToRemove = int.Parse(data[1]);

                if (stackOfNumbers.Count >= countOfNumbersToRemove)
                {
                    for (int i = 0; i < countOfNumbersToRemove; i++)
                    {
                        stackOfNumbers.Pop();
                    }
                }
            }

            input = Console.ReadLine().ToLower();
        }

        if (stackOfNumbers.Count > 0 )
        {
            int sumOfElementsInStack = 0;

            foreach (var element in stackOfNumbers)
            {
                sumOfElementsInStack += element;
            }

            Console.WriteLine($"Sum: {sumOfElementsInStack}");

        
        }


    }
}

