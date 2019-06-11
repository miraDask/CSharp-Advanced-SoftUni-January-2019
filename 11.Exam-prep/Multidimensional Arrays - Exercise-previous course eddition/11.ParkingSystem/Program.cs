namespace _11.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] dimentionsOfParking = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int parkingRows = dimentionsOfParking[0];
            int parkingCols = dimentionsOfParking[1];

            List<int[]> parking = new List<int[]>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                int[] parkingArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = parkingArgs[0];
                int targetRow = parkingArgs[1];
                int targetCol = parkingArgs[2];

                int movesCount = Math.Abs(targetRow - entryRow) + 1;

                if (parking.Any(x => x[0] == targetRow && x[1] == targetCol) == false)
                {
                    parking.Add(new int[] { targetRow, targetCol });
                    movesCount += targetCol;
                    Console.WriteLine(movesCount);
                }
                else
                {
                    if (dimentionsOfParking[1] == 2)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                        continue;
                    }


                    int newParkingSpot = GetSpot(targetCol, targetRow, parking, parkingRows, parkingCols);

                    if (newParkingSpot != targetCol)
                    {
                        parking.Add(new int[] {targetRow, newParkingSpot});
                        movesCount += newParkingSpot;
                        Console.WriteLine(movesCount);
                    }
                    else
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                }
            }
        }

        private static int GetSpot(int targetCol, int targetRow, List<int[]> parking, int parkingRows, int parkingCols)
        {
            
            int colDiff = 0;

            if (targetCol >= parkingCols / 2)
            {
                colDiff = targetCol - 1;
            }
            else
            {
                colDiff = parkingCols - targetCol - 1;
            }

            int count = 1;

            while (count <= colDiff)
            {
                bool isInParkingRange = GetVerification(parkingCols, targetCol - count);

                if (isInParkingRange && parking.Any(x => x[0] == targetRow && x[1] == targetCol - count) == false)
                {
                    return targetCol - count;
                }

                isInParkingRange = GetVerification(parkingCols, targetCol + count);

                if (isInParkingRange && parking.Any(x => x[0] == targetRow && x[1] == targetCol + count) == false)
                {
                    return targetCol + count;
                }

                count++;
            }

            return targetCol;
        }

        private static bool GetVerification(int parkingCols, int targetCol)
        {
            return targetCol >= 1 && targetCol < parkingCols;
        }
    }
}
