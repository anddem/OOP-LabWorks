using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork_12;
using LabWork_10;

namespace LabTests
{
    [TestClass]
    public class MyCollectionTest
    {
        [TestMethod]
        public void TestContains()
        {
            Place[] places = new Place[]
            {
                new Place("1"),
                new Address("2", "2", 2),
                new Region("3", 3),
                new City("4", 4, 4, new Address("4", "4", 4))
            };

            Place[] copies = new Place[]
            {
                (Place)places[0].Clone(),
                (Address)((Address)places[1]).Clone(),
                (Region)((Region)places[2]).Clone(),
                (City)((City)places[3]).Clone()
            };

            MyCollection<Place> collection = new MyCollection<Place>();
            collection.Add(places);

            Assert.IsTrue(collection.Contains(copies[0]));
            Assert.IsTrue(collection.Contains(copies[1]));
            Assert.IsTrue(collection.Contains(copies[2]));
            Assert.IsTrue(collection.Contains(copies[3]));
        }
    }
}
