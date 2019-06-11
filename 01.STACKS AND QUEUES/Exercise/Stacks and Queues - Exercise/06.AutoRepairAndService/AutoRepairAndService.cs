using System;
using System.Collections.Generic;
using System.Text;

public class AutoRepairAndService
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();

        Queue<string> waitingForServiceVehicles = new Queue<string>(input);

        Stack<string> servedVehicles = new Stack<string>();

        StringBuilder sb = new StringBuilder();

        string command = Console.ReadLine();

        while (command != "End")
        {

            switch (command)
            {
                case "Service":
                    if (waitingForServiceVehicles.Count > 0)
                    {
                        string currentVehicle = waitingForServiceVehicles.Dequeue();

                        sb.AppendLine($"Vehicle {currentVehicle} got served.");

                        servedVehicles.Push(currentVehicle);
                    }

                    break;
                case "History":

                    sb.AppendLine(string.Join(", ", servedVehicles));
                    break;

                default:
                    string[] vehicleData = command.Split('-');
                    string modelName = vehicleData[1];

                    if (servedVehicles.Contains(modelName))
                    {
                        sb.AppendLine("Served.");
                    }
                    else if (waitingForServiceVehicles.Contains(modelName))
                    {
                        sb.AppendLine("Still waiting for service.");
                    }
                    break;

            }

            command = Console.ReadLine();
        }

        if (waitingForServiceVehicles.Count > 0)
        {
            sb.AppendLine($"Vehicles for service: {string.Join(", ", waitingForServiceVehicles)}");
        }

        if (servedVehicles.Count > 0)
        {
            sb.AppendLine($"Served vehicles: {string.Join(", ", servedVehicles)}");
        }


        Console.Write(sb);
    }
}

