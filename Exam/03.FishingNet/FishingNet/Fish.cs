namespace FishingNet
{
    public class Fish
    {
        public string FishType;
        public double Length;
        public double Weight;
        public Fish(string type, double lenght, double weight)
        {
            FishType = type;
            Length = lenght;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }
    }
}
