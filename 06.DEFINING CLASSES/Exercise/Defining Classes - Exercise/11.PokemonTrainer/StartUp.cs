namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainersList = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] trainerData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = trainerData[0];
                string pokemonName = trainerData[1];
                string pokemonElement = trainerData[2];
                int pokemonHealth = int.Parse(trainerData[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainersList.Any(x => x.Name == trainerName))
                {
                    trainersList.Add(new Trainer(trainerName));
                }

                var trainer = trainersList.Find(x => x.Name == trainerName);
                trainer.PokemonCollection.Add(pokemon);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                foreach (var trainer in trainersList)
                {
                    if (trainer.PokemonCollection.Any(x => x.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.PokemonCollection)
                        {
                            pokemon.Health -= 10;

                        }
                    }

                    trainer.PokemonCollection = trainer.PokemonCollection.Where(x => x.Health > 0).ToList();
                }
            }

            foreach (var trainer in trainersList.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonCollection.Count}");
            }
        }
    }
}
