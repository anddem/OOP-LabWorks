using System;

namespace LabWork_10
{
    public class Region : Place
    {
        private int population;

        public int Population //Население региона
        {
            get => population;
            set
            {
                if (value >= 0) population = value;
                else population = 0;
            }
        }

        public Region() : base("Регион без имени") { }

        public Region(string name, int population = 0)
        {
            if (String.IsNullOrWhiteSpace(name)) name = "Регион без имени";
            Name = name;
            Population = population;
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Население: {Population}");
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"Население: {Population}");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nНаселение: {Population}";
        }

        public new object Clone()
        {
            return new Region($"Клон {Name}", Population);
        }

        public new object ShallowCopy()
        {
            return (Region)this.MemberwiseClone();
        }

        public new int CompareTo(object obj)
        {
            Region temp = (Region)obj;

            if (String.Compare(temp.Name, this.Name) != 0) return String.Compare(temp.Name, this.Name);

            if (temp.Population > this.Population) return 1;
            if (temp.Population < this.Population) return -1;

            return 0;
        }
    }
}
