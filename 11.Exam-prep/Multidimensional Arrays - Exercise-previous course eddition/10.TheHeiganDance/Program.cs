namespace _10.TheHeiganDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int plagueCloudDamage = 3500;
            int eruptionDamage = 6000;
            int playerHealthPoints = 18500;
            double bossHealthPoints = 3000000;
            int playerRow = 7;
            int playerCol = 7;
            int[] playerPosition = { playerRow, playerCol };

            Queue<int> spellsForNextTurn = new Queue<int>();

            double playerDamage = double.Parse(Console.ReadLine());

            while (playerHealthPoints > 0 && bossHealthPoints > 0)
            {
                string[] spellArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string spell = spellArgs[0];
                int spellRow = int.Parse(spellArgs[1]);
                int spellCol = int.Parse(spellArgs[2]);
                int[] playerNewPosition = new int[2];
                bool bossIsDead = false;

                int spellDamage = 0;

                if (spell == "Cloud")
                {
                    spellDamage = plagueCloudDamage;
                }
                else
                {
                    spellDamage = eruptionDamage;
                }


                bossHealthPoints -= playerDamage;

                if (bossHealthPoints <= 0)
                {

                    bossIsDead = true;
                }

                if (spellsForNextTurn.Any())
                {
                    playerHealthPoints -= spellsForNextTurn.Dequeue();
                }

                if (bossIsDead && playerHealthPoints <= 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    Console.WriteLine("Player: Killed by Plague Cloud");
                    Console.WriteLine($"Final position: {playerPosition[0]}, {playerPosition[1]}");
                    break;
                }
                else if (bossIsDead)
                {
                    PrintBossInfo(playerHealthPoints, playerPosition);
                    break;
                }
                else if (playerHealthPoints <= 0)
                {
                    PrintPlayerInfo("Cloud", bossHealthPoints, playerPosition);
                    break;
                }

                bool needToMove = CheckIfPlayerIsInRangeOfSpell(playerPosition, spellRow, spellCol);

                if (needToMove)
                {
                    playerNewPosition = HerroEscapeCheck(playerPosition, spellRow, spellCol);

                    if (playerPosition == playerNewPosition)
                    {
                        playerHealthPoints -= spellDamage;

                        if (spell == "Cloud")
                        {
                            spellsForNextTurn.Enqueue(plagueCloudDamage);
                        }
                    }
                    else
                    {
                        playerPosition = playerNewPosition;
                    }

                    if (playerHealthPoints <= 0)
                    {
                        PrintPlayerInfo(spell, bossHealthPoints, playerPosition);
                        break;
                    }
                }
            }
        }

        private static bool CheckIfPlayerIsInRangeOfSpell(int[] playerPosition, int spellRow, int spellCol)
        {
            List<int[]> spellRange = new List<int[]>{ new int[] {spellRow,spellCol}
            , new int[] { spellRow - 1, spellCol -1}
            ,new int[] { spellRow - 1, spellCol}
            ,new int[] { spellRow - 1, spellCol +1}
            ,new int[] { spellRow , spellCol +1}
            ,new int[] { spellRow +1, spellCol +1}
            ,new int[] { spellRow+ 1, spellCol - 1}
            ,new int[] { spellRow+ 1, spellCol}
            ,new int[] { spellRow , spellCol -1}};

            if (spellRange.Any(s => s[0] == playerPosition[0] && s[1] == playerPosition[1]))
            {
                return true;
            }

            return false;
        }

        private static void PrintPlayerInfo(string spell, double bossHealthPoints, int[] playerPosition)
        {
            if (spell == "Cloud")
            {
                spell = "Plague Cloud";
            }
            Console.WriteLine($"Heigan: {bossHealthPoints:F2}{Environment.NewLine}" +
                $"Player: Killed by {spell}{Environment.NewLine}" +
                $"Final position: {playerPosition[0]}, {playerPosition[1]}");
        }

        private static void PrintBossInfo(double playerHealthPoints, int[] playerPosition)
        {
            Console.WriteLine($"Heigan: Defeated!{Environment.NewLine}" +
                $"Player: {playerHealthPoints}{Environment.NewLine}" +
                $"Final position: {playerPosition[0]}, {playerPosition[1]}");
        }

        private static int[] HerroEscapeCheck(int[] playerPosition, int spellRow, int spellCol)
        {
            List<int[]> spellRange = new List<int[]>{ new int[] {spellRow,spellCol}
            , new int[] { spellRow - 1, spellCol -1}
            ,new int[] { spellRow - 1, spellCol}
            ,new int[] { spellRow - 1, spellCol +1}
            ,new int[] { spellRow , spellCol +1}
            ,new int[] { spellRow +1, spellCol +1}
            ,new int[] { spellRow+ 1, spellCol - 1}
            ,new int[] { spellRow+ 1, spellCol}
            ,new int[] { spellRow , spellCol -1}};

            if (!spellRange.Any(s => s[0] == playerPosition[0] && s[1] == playerPosition[1]))
            {
                return playerPosition;
            }
            else
            {
                int[] playerNewPosition = { playerPosition[0] - 1, playerPosition[1] };

                if (!spellRange.Any(s => s[0] == playerNewPosition[0] && s[1] == playerNewPosition[1])
                    && playerNewPosition[0] >= 0)
                {
                    return playerNewPosition;
                }

                playerNewPosition = new int[] { playerPosition[0], playerPosition[1] + 1 };

                if (!spellRange.Any(s => s[0] == playerNewPosition[0] && s[1] == playerNewPosition[1])
                    && playerNewPosition[1] < 15)
                {
                    return playerNewPosition;
                }

                playerNewPosition = new int[] { playerPosition[0] + 1, playerPosition[1] };

                if (!spellRange.Any(s => s[0] == playerNewPosition[0] && s[1] == playerNewPosition[1])
                    && playerNewPosition[0] < 15)
                {
                    return playerNewPosition;
                }

                playerNewPosition = new int[] { playerPosition[0], playerPosition[1] - 1 };

                if (!spellRange.Any(s => s[0] == playerNewPosition[0] && s[1] == playerNewPosition[1])
                    && playerNewPosition[1] >= 0)
                {
                    return playerNewPosition;
                }

                return playerPosition;
            }
        }
    }
}
