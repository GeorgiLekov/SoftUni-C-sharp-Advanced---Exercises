using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string nameInput, int ageInput)
        {
            Name = nameInput;
            Age = ageInput;
        }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int ageInput):this()
        {
            Age = ageInput;
        }
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value;}
        }
    }
}
