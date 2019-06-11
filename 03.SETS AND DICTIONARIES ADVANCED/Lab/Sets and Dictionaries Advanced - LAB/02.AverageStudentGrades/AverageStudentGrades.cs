using System;
using System.Collections.Generic;
using System.Linq;

class AverageStudentGrades
{
    static void Main()
    {
        int numOfDataLines = int.Parse(Console.ReadLine());
        Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

        for (int i = 0; i < numOfDataLines; i++)
        {
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            double grade = double.Parse(data[1]);

            if (students.ContainsKey(name) == false)
            {
                students.Add(name, new List<double>());
            }

            students[name].Add(grade);
        }

        foreach (var pair in students)
        {
            double avarage = pair.Value.Average();

            Console.Write($"{pair.Key} -> ");

            foreach (var grades in pair.Value)
            {
                Console.Write($"{grades:F2} ");
            }
            Console.WriteLine($"(avg: {avarage:F2})");
        }
    }


}

