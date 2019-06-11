namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<Employee>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] employeeData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string position = employeeData[2];
                string department = employeeData[3];
                string email;
                int age;

                Employee currentEmployee = new Employee(name, salary, position, department);

                if (employeeData.Length == 5)
                {
                    if (employeeData[4].Contains('@'))
                    {
                        email = employeeData[4];
                        currentEmployee = new Employee(name, salary, position, department, email);
                    }
                    else
                    {
                        age = int.Parse(employeeData[4]);
                        currentEmployee = new Employee(name, salary, position, department, age);
                    }
                }
                else if (employeeData.Length == 6)
                {
                    if (employeeData[4].Contains('@'))
                    {
                        email = employeeData[4];
                        age = int.Parse(employeeData[5]);
                    }
                    else
                    {
                        age = int.Parse(employeeData[4]);
                        email = employeeData[4];
                    }

                    currentEmployee = new Employee(name, salary, position, department, email, age);
                }

                if (!departments.ContainsKey(currentEmployee.Department))
                {
                    departments[currentEmployee.Department] = new List<Employee>();
                }

                departments[currentEmployee.Department].Add(currentEmployee);
            }

            double highesAvarageSalary = departments
                .Select(x => x.Value.Select(y => y.Salary).Average())
                .Max();

            var highesAvarageSalaryDepartment = departments.
                FirstOrDefault(x => x.Value
                   .Select(y => y.Salary)
                   .Average() == highesAvarageSalary);

            Console.WriteLine($"Highest Average Salary: {highesAvarageSalaryDepartment.Key}");

            foreach (var employee in highesAvarageSalaryDepartment
                .Value
                .OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
