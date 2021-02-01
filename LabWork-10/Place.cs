﻿using System;

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
            return new Place($"Клон {Name}");
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
    }
}
