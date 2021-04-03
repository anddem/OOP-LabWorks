using System;

namespace LabWork_10
{
    public class City : Region
    {
        private Address copyAddress;

        public Address CopyAddress
        {
            get => copyAddress;
            set => copyAddress = value == null ? new Address() : value;
        }

        private int houses;

        public int Houses
        {
            get => houses;
            set
            {
                if (value >= 0) houses = value;
                else houses = 0;
            }
        }

        public City() : base("Город без имени") { } //base() - вызов конструктора базового класса

        public City(string name, int population = 0, int houses = 0, Address copyAdr = null)
        {
            if (String.IsNullOrWhiteSpace(name)) name = "Город без имени";
            Name = name;
            Population = population;
            Houses = houses;
            CopyAddress = copyAdr;
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Количество домов: {Houses}");
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"Количество домов: {Houses}");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nДомов: {Houses}";
        }

        public new object Clone()
        {
            return new City(Name, Population, Houses, (Address)CopyAddress.Clone());
        }

        public new object ShallowCopy()
        {
            return (City)this.MemberwiseClone();
        }

        public new int CompareTo(object obj)
        {
            City temp = (City)obj;

            if (String.Compare(temp.Name, this.Name) != 0) return String.Compare(temp.Name, this.Name);

            if (temp.Population > this.Population) return 1;
            if (temp.Population < this.Population) return -1;
            if (temp.Houses > this.Houses) return 1;
            if (temp.Houses < this.Houses) return -1;

            return 0;
        }
    }
}
