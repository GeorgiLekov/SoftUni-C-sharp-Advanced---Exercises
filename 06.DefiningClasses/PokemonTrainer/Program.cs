using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string command = Console.ReadLine();
            while(command != "Tournament")
            {
                string[] instruction = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = instruction[0];
                string pokemonName = instruction[1];
                string pokemonElement = instruction[2];
                int pokemonHealth = int.Parse(instruction[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer tempTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, tempTrainer);
                }
                Pokemon tempPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers[trainerName].pokemons.Add(tempPokemon);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                switch (command)
                {
                    case "Fire":
                        AwardingAndKilling(trainers, "Fire");
                        break;
                    case "Electricity":
                        AwardingAndKilling(trainers, "Electricity");
                        break;
                    case "Water":
                        AwardingAndKilling(trainers, "Water");
                        break;
                }
                command = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.Value.Badge).ToDictionary(k => k.Key, v => v.Value);

            foreach(var trainer in trainers)
            {
                Console.WriteLine(trainer.Value.ToString());
            }
        }

        public static void AwardingAndKilling(Dictionary<string,Trainer> trainers, string element)
        {
            foreach(var trainer in trainers)
            {
                bool hasMonsterOfTheType = false;
                foreach(var pokemon in trainer.Value.pokemons)
                {
                    if (pokemon.Element == element)
                    {
                        hasMonsterOfTheType = true;
                        break;
                    }
                }
                if (hasMonsterOfTheType) trainer.Value.Badge ++;
                else
                {
                    
                    for(int i = 0; i < trainer.Value.pokemons.Count; i++)
                    {
                        trainer.Value.pokemons[i].Health -= 10;
                        if (trainer.Value.pokemons[i].Health <= 0)
                        {
                            trainer.Value.pokemons.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
    }
}
