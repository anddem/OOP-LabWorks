using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_12;
using LabWork_10;

namespace LabWork_13
{
    class Program
    {
        static void Main(string[] args)
        {
            NewCollection<Place> placesOne = new NewCollection<Place>("Первая коллекция");
            NewCollection<Place> placesTwo = new NewCollection<Place>("Вторая коллекция");
            Journal journalOne = new Journal("Журнал номер 1");
            Journal journalTwo = new Journal("Журнал номер 2");

            placesOne.CollectionCountChanged += new CollectionHandler(journalOne.CollectionCountChanged);
            placesOne.CollectionReferenceChanged += new CollectionHandler(journalOne.CollectionReferenceChanged);
            placesOne.CollectionReferenceChanged += new CollectionHandler(journalTwo.CollectionReferenceChanged);
            placesTwo.CollectionReferenceChanged += new CollectionHandler(journalTwo.CollectionReferenceChanged);

            placesOne.Add(new Place());
            placesOne.Add(new Region());
            placesOne.Add(new Place());
            placesOne.Add(new Address());

            placesTwo.Add(new Place());
            placesTwo.Add(new Region());
            placesTwo.Add(new Place());
            placesTwo.Add(new Address());

            placesTwo[1] = new Address();
            placesOne[1] = new Address();
            placesTwo[0] = new Region();

            placesOne.Remove(new Place());
            placesTwo.Remove(new Region());

            journalOne.Show();
            journalTwo.Show();
        }
    }
}
