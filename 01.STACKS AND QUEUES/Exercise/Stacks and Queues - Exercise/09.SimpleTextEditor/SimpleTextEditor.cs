using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SimpleTextEditor
{
    static void Main()
    {
        int numberOfOperations = int.Parse(Console.ReadLine());

        StringBuilder text = new StringBuilder();

        Stack<string> textPhases = new Stack<string>();



        for (int i = 0; i < numberOfOperations; i++)
        {
            string[] currentLine = Console.ReadLine().Split();

            string command = currentLine[0];



            switch (command)
            {
                case "1":

                    string currentText = currentLine[1];
                    textPhases.Push(text.ToString());
                    text.Append(currentText);


                    break;

                case "2":

                    int countOfElementsToRemove = int.Parse(currentLine[1]);

                    if (text.Length > 0)
                    {
                        int startIndexForRemoval = text.Length - countOfElementsToRemove;

                        textPhases.Push(text.ToString());

                        text.Remove(startIndexForRemoval, countOfElementsToRemove);

                    }

                    break;

                case "3":

                    int indexOfElementToReturn = int.Parse(currentLine[1]);

                    if (text.Length > 0)
                    {
                        char element = GetElement(indexOfElementToReturn, text);
                        Console.WriteLine(element);
                    }


                    break;

                case "4":

                    text = new StringBuilder(textPhases.Pop());
                    break;

            }

        }
    }

    private static char GetElement(int indexOfElementToReturn, StringBuilder text)
    {
        char element = ' ';

        for (int i = 0; i < text.Length; i++)
        {
            if (i + 1 == indexOfElementToReturn)
            {
                element = text[i];
            }
        }

        return element;
    }
}

