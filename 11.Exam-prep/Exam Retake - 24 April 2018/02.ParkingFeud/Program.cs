namespace _02.ParkingFeud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {

        public static void Main()
        {

            int[] parkingData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int parkingSpotsRows = parkingData[0];
            int parkingSpotsCols = parkingData[1];
            int totalParkingRows = parkingSpotsRows * 2 - 1;
            int[][] parking = new int[totalParkingRows][];

            List<int> entranceRows = GetRows(totalParkingRows, "entranceRow");
            List<int> parkingRows = GetRows(totalParkingRows, "parkingSpotRow");

            int entrance = int.Parse(Console.ReadLine());
            int samTotalMoves = 0;
            string targetParkingSpot = string.Empty;

            while (true)
            {
                string[] parkingSpots = Console.ReadLine()
                    .Split();

                targetParkingSpot = parkingSpots[entrance - 1];
                int samEntranceRow = entranceRows[entrance - 1];
                int targetParkingSpotRow = int.Parse(targetParkingSpot[1].ToString());

                if (targetParkingSpotRow > parkingSpotsRows)
                {
                    parkingRows.Add(parkingRows[parkingRows.Count - 1] + 2);
                    totalParkingRows = targetParkingSpotRow * 2 - 1;
                    parking = new int[totalParkingRows][];

                }

                int dublicatedSpotIndex = GetDublicationInfo(parkingSpots, targetParkingSpot, entrance, entranceRows);
                int parkingSpotRow = parkingRows[int.Parse(targetParkingSpot[1].ToString()) - 1];
                int parkingSpotCol = targetParkingSpot[0] - 64;
                int samsMovesToSpot = GetMovesToParkingSpot(parkingSpotRow, parkingSpotCol, parkingSpotsCols, samEntranceRow, parking);


                if (dublicatedSpotIndex == -1)
                {
                    samTotalMoves += samsMovesToSpot;
                    break;
                }

                int otherCarEntranceRow = entranceRows[dublicatedSpotIndex];
                int otherCarMovesToSpot = GetMovesToParkingSpot
                                           (parkingSpotRow, parkingSpotCol, parkingSpotsCols, otherCarEntranceRow, parking);

                if (samsMovesToSpot > otherCarMovesToSpot)
                {

                    samTotalMoves += samsMovesToSpot * 2;
                    continue;
                }
                else
                {
                    samTotalMoves += samsMovesToSpot;
                    break;
                }
            }

            Console.WriteLine($"Parked successfully at {targetParkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {samTotalMoves}");
        }

        private static int GetMovesToParkingSpot(int parkingSpotRow, int parkingSpotCol, int parkingSpotsCols, int entrancRow, int[][] parking)
        {
            int rowsDiff = Math.Abs(parkingSpotRow - entrancRow) / 2;
            int moves = (rowsDiff * parkingSpotsCols) + 3 * rowsDiff;
            int targetRowNum = rowsDiff + 1;

            if (targetRowNum % 2 == 1)
            {
                for (int col = 1; col <= parkingSpotsCols; col++)
                {
                    moves++;
                    if (col == parkingSpotCol)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int col = parkingSpotsCols; col >= 1; col--)
                {
                    moves++;
                    if (col == parkingSpotCol)
                    {
                        break;
                    }
                }
            }

            return moves;
        }

        private static List<int> GetRows(int totalParkingRows, string definition)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < totalParkingRows; i++)
            {
                if (i % 2 == 1 && definition == "entranceRow")
                {
                    result.Add(i);
                }
                else if (i % 2 == 0 && definition == "parkingSpotRow")
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static int GetDublicationInfo(string[] parkingSpots, string targetParkingSpot, int entrance, List<int> entranceRows)
        {
            for (int i = 0; i < entranceRows.Count; i++)
            {
                string currentSpot = parkingSpots[i];
                if (currentSpot == targetParkingSpot && i != entrance - 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
