using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;

        public string Material;
        public int Capacity;
        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            this.Material = material;
            this.Capacity = capacity;
        }

        public int Count
        {
            get { return Fish.Count; }
        }

        public string AddFish(Fish fish)
        {
            if (fish.Weight <= 0 && fish.Length <= 0 && string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            if (Fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            for(int i = 0; i < this.Fish.Count; i++)
            {
                if (Fish[i].Weight == weight)
                {
                    Fish.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            for(int i = 0; i < this.Fish.Count; i++)
            {
                if (Fish[i].FishType == fishType)
                {
                    return Fish[i];
                }
            }
            return null;
        }

        public Fish GetBiggestFish()
        {
            double lenghtMax = double.MinValue;
            int index = 0;
            for(int i = 0; i < this.Fish.Count; i++)
            {
                if (lenghtMax < Fish[i].Weight)
                {
                    lenghtMax = Fish[i].Weight;
                    index = i;
                }
            }

            return Fish[index];
        }

        public string Report()
        {
            Fish = Fish.OrderByDescending(x => x.Length).ToList();
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Into the {Material}:");
            foreach(var item in Fish)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
