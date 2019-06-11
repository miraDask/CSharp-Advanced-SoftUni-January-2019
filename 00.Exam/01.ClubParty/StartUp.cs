namespace _01.ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Hall
    {
        public Hall(int capacity, char symbol)
        {
            Symbol = symbol;
            Capacity = capacity;
            People = new List<int>();
        }

        public char Symbol { get; set; }
        public int Capacity { get; set; }

        public List<int> People { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            List<Hall> halls = new List<Hall>();

            int capacity = int.Parse(Console.ReadLine());
            string[] sequence = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);


            int people = -1;
            char hall = ' ';
           
            for (int i = sequence.Length -1; i >= 0; i--)
            {
                try
                {
                    people = int.Parse(sequence[i]);
                }
                catch (Exception)
                {
                  hall = char.Parse(sequence[i]);
                  
                }

                if (hall != ' ' )
                {
                    if (!halls.Any(x => x.Symbol == hall))
                    {
                        halls.Add(new Hall(capacity, hall));
                       
                    }
                }
                else 
                {
                    people = -1;
                    continue;
                }

                if (people > -1)
                {
                    Hall currentHall = halls.First();

                    if (people <= currentHall.Capacity)
                    {
                        currentHall.People.Add(people);
                        currentHall.Capacity -= people;
                        people = -1;

                        if (currentHall.Capacity == 0)
                        {
                            Console.WriteLine($"{currentHall.Symbol} -> {string.Join(", ", currentHall.People)} ");
                            halls.RemoveAt(0);
                           
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{currentHall.Symbol} -> {string.Join(", ", currentHall.People)} ");
                        halls.RemoveAt(0);
                        people = -1;

                        if (halls.Any())
                        {
                            currentHall = halls.First();
                            currentHall.People.Add(people);
                            currentHall.Capacity -= people;
                            people = -1;
                            

                        }

                    }
                }
             

            }
        }
    }
}
