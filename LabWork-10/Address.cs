using System;

namespace LabWork_10
{
    public class Address : Place
    {
        private string street = "Улица не указана";
        private int houseNum = 1;

        public string Street
        {
            get => street;
            set
            {
                if (!String.IsNullOrWhiteSpace(value)) street = value;
                else street = "Улица не указана";
            }
        }

        public int HouseNumber
        {
            get => houseNum;
            set
            {
                if (value > 0) houseNum = value;
                else houseNum = 1;
            }
        }

        public Address() : base("Адрес без названия") { }

        public Address(string name, string street, int house)
        {
            if (String.IsNullOrWhiteSpace(name)) name = "Адрес без названия";
            Name = name;
            (Street, HouseNumber) = (street, house);
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("" +
                $"Улица: {Street}\n" +
                $"Дом: {HouseNumber}\n");
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine("" +
                $"Улица: {Street}\n" +
                $"Дом: {HouseNumber}");
        }

        public override string ToString()
        {
            return base.ToString() +
                $"Улица: {Street}\n" +
                $"Дом: {HouseNumber}";
        }

        public new object Clone()
        {
            return new Address(Name, Street, HouseNumber);
        }

        public new object ShallowCopy()
        {
            return (Address)this.MemberwiseClone();
        }

        public new int CompareTo(object obj)
        {
            Address temp = (Address)obj;

            if (String.Compare(temp.Name, this.Name) != 0) return String.Compare(temp.Name, this.Name);
            if (String.Compare(temp.Street, this.Street) != 0) return String.Compare(temp.Street, this.Street);
            if (temp.HouseNumber > this.HouseNumber) return 1;
            if (temp.HouseNumber < this.HouseNumber) return -1;

            return 0;
        }
    }
}
