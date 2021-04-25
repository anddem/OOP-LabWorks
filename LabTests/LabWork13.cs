using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork_13;
using LabWork_10;

namespace LabTests
{
    [TestClass]
    public class LabWork13
    {
        [TestMethod]
        public void CountChangedTest()
        {
            NewCollection<Place> places = new NewCollection<Place>("Тестовая коллекция");
            Journal j = new Journal("Тестовый журнал");

            places.CollectionCountChanged += new CollectionHandler(j.CollectionCountChanged);

            //Act
            places.Add(new Place());
            places.Remove(new Place());

            //Assert
            Assert.AreEqual(2, j.Count);
        }

        [TestMethod]
        public void ReferenceChangedTest()
        {
            NewCollection<Place> places = new NewCollection<Place>("Тестовая коллекция");
            Journal j = new Journal("Тестовый журнал");

            places.CollectionReferenceChanged += new CollectionHandler(j.CollectionReferenceChanged);
            places.Add(new Place());
            places.Add(new Region());

            places.Add(new Place());
            places.Add(new Region());
            places.Add(new Place());
            places.Add(new Address());

            places[1] = new Address();

            //Assert
            Assert.AreEqual(1, j.Count);
        }
    }
}
