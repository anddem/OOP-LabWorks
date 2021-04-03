using System;

namespace LabWork_10
{
    public class Place : IExecutable, ICloneable, IComparable
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (!String.IsNullOrWhiteSpace(value)) name = value;
                else name = "Абстрактное место";
            }
        }

        public Place() => Name = "Абстрактное место";

        public Place(string name) => Name = name;

        public void PrintInfo() //Будет перегружено
        {
            Console.WriteLine($"Название: {Name}");
        }

        public virtual void PrintInformation()
        {
            Console.WriteLine($"Название: {Name}");
        }

        public override string ToString()
        {
            return $"Название: {Name}";
        }

        public object Clone()
        {
            return new Place(Name);
        }

        public object ShallowCopy()
        {
            return (Place)this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Place temp = (Place)obj;
            return String.Compare(temp.Name, this.Name);
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            Place place = (Place)obj;

            return this.Name == place.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator > (Place left, Place right)
        {
            return string.Compare(left.Name, right.Name) == 1;
        }

        public static bool operator < (Place left, Place right)
        {
            return string.Compare(left.Name, right.Name) == -1;
        }

        public static bool operator == (Place left, Place right)
        {
            return string.Compare(left.Name, right.Name) == 0;
        }

        public static bool operator !=(Place left, Place right)
        {
            return string.Compare(left.Name, right.Name) != 0;
        }
    }
}
