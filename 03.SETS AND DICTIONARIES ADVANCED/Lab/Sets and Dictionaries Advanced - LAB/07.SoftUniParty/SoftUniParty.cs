using System;
using System.Collections.Generic;

public class SoftUniParty
{
    public static void Main()
    {
        HashSet<string> reservations = new HashSet<string>();
        HashSet<string> vipReservations = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "party")
            {
                break;
            }

            if (input.Length == 8)
            {

                if (!char.IsDigit(input[0]))
                {
                    reservations.Add(input);
                }
                else
                {
                    vipReservations.Add(input);
                }
            }

        }


        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "end")
            {
                break;
            }

            if (reservations.Contains(input))
            {
                reservations.Remove(input);
            }

            if (vipReservations.Contains(input))
            {
                vipReservations.Remove(input);
            }

        }


        Console.WriteLine(reservations.Count + vipReservations.Count);

        if (vipReservations.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, vipReservations));
        }

        if (reservations.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, reservations));
        }



    }
}

