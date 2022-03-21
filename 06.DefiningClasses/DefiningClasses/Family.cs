using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person anotherMember)
        {
            members.Add(anotherMember);
        }

        public Person GetOldestMember()
        {
            Person temp = new Person();

            temp.Age = int.MinValue;

            for(int i = 0; i < members.Count; i++)
            {
                if (temp.Age < members[i].Age) temp = members[i];
            }

            return temp;
        }
    }
}
