using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Trainer
    {
        private string name;
        private int badge;
        public List<Pokemon> pokemons;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Badge
        {
            get
            {
                return badge;
            }
            set
            {
                badge = value;
            }
        }

        public Trainer()
        {
            Name = string.Empty;
            Badge = 0;
            pokemons = new List<Pokemon>();
        }
        public Trainer(string nameInput) : this()
        {
            Name = nameInput;
        }

        public override string ToString()
        {
            return $"{Name} {Badge} {pokemons.Count}";
        }
    }
}
