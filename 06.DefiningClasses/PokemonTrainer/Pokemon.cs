using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Pokemon
    {
        private string name;
        private string element;
        private int health;

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
        public string Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public Pokemon()
        {

        }

        public Pokemon(string nameInput, string elementInput, int healthInput)
        {
            Name = nameInput;
            Element = elementInput;
            Health = healthInput;
        }
    }
}
