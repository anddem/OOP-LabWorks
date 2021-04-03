using System;

namespace LabWork_10
{
    public class Region : Place
    {
        public Place BasePlace
        {
            get => new Place(Name);
        }

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
            return new Region(Name, Population);
        }

        public new object ShallowCopy()
        {
            return (Region)this.MemberwiseClone();
        }

        public new int CompareTo(object obj)
        {
            Region temp = (Region)obj;

            if (String.Compare(temp.Name, this.Name) != 0) return String.Compare(temp.Name, this.Name);

            if (this.Population > temp.Population) return 1;
            if (this.Population < temp.Population) return -1;

            return 0;
        }

        public static bool operator >(Region left, Region right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator <(Region left, Region right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator ==(Region left, Region right)
        {
            return string.Compare(left.Name, right.Name) == 0 && left.Population == right.Population;
        }

        public static bool operator !=(Region left, Region right)
        {
            return string.Compare(left.Name, right.Name) != 0 || left.Population != right.Population;
        }
    }
}
