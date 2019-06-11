﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MaximumAndMinimumElement
{
    public static void Main()
    {
        int countOfLines = int.Parse(Console.ReadLine());

        Stack<int> numbers = new Stack<int>();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < countOfLines; i++)
        {
            string currentInput = Console.ReadLine();

            switch (currentInput)
            {
                case "2":
                    if (numbers.Any())
                    {
                        numbers.Pop();
                    }
                    break;

                case "3":
                    if (numbers.Any())
                    {
                        sb.AppendLine(numbers.Max().ToString());
                    }
                    break;
                case "4":
                    if (numbers.Any())
                    {
                        sb.AppendLine(numbers.Min().ToString());
                    }
                    break;

                default:
                    string[] lineData = currentInput.Split();
                    int currentNum = int.Parse(lineData[1]);

                    numbers.Push(currentNum);

                    break;
            }


        }

        sb.AppendLine(string.Join(", ", numbers));

        Console.Write(sb);
    }
}

