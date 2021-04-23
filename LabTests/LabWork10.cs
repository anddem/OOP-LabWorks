using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork_10;

namespace LabTests
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void EmptyConstruct()
        {
            //Arrange
            Place place;
            string name = "Абстрактное место";

            //Act
            place = new Place();

            //Assert
            Assert.AreEqual(place.Name, name);
        }

        [DataTestMethod]
        [DataRow(" ")]
        [DataRow("Место")]
        public void DataConstruct(string data)
        {
            //Arrange
            Place place;
            string name = "Абстрактное место";
            if (!String.IsNullOrWhiteSpace(data)) name = data;

            //Act
            place = new Place(data);

            //Assert
            Assert.AreEqual(place.Name, name);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("Changed")]
        public void ChangePlaceName(string data)
        {
            //Arrange
            Place place = new Place();
            string name = "Абстрактное место";

            if (!String.IsNullOrWhiteSpace(data)) name = data;

            place.Name = data;

            Assert.AreEqual(name, place.Name);
        }
    }

    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void EmptyConstruct()
        {
            //Arrange
            Region reg;
            string name = "Регион без имени";
            int pop = 0;

            //Act
            reg = new Region();

            //Assert
            Assert.IsTrue(reg.Name == name && reg.Population == pop);
        }

        [DataTestMethod]
        [DataRow("", -1)]
        [DataRow(" ", 1)]
        [DataRow("Регион", -5)]
        [DataRow("Регион", 10)]
        public void DataConstruct(string dataName, int dataPop)
        {
            //Arrange
            Region reg;
            string name = "Регион без имени";
            int pop = 0;

            if (!String.IsNullOrWhiteSpace(dataName)) name = dataName;
            if (dataPop >= 0) pop = dataPop;

            //Act
            reg = new Region(name, pop);

            Assert.IsTrue(reg.Name == name && reg.Population == pop);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(1001)]
        public void ChangePop(int data)
        {
            //Arrange
            Region reg = new Region();
            int pop = 0;

            if (data >= 0) pop = data;

            //Act
            reg.Population = data;

            //Assert
            Assert.AreEqual(pop, reg.Population);
        }
    }

    [TestClass]
    public class CityTest
    {
        [TestMethod]
        public void EmptyConstruct()
        {
            //Arrange
            City city;

            //Act
            city = new City();

            Assert.IsTrue(
                city.Name == "Город без имени" &&
                city.Population == 0 &&
                city.Houses == 0
                );
        }

        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void DataConstruct(int dataHss)
        {
            //Arrange
            City city;
            int hss = 0;

            if (dataHss >= 0) hss = dataHss;

            //Act
            city = new City("Город", 1100, dataHss);

            //Assert
            Assert.AreEqual(hss, city.Houses);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(500)]
        public void ChangeHouses(int data)
        {
            //Arrange
            City city = new City();

            int hss = data >= 0 ? data : 0;

            //Act
            city.Houses = data;

            //Assert
            Assert.AreEqual(hss, city.Houses);
        }
    }

    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void EmptyConstruct()
        {
            //Arrange
            Address adr;

            //Act
            adr = new Address();

            //Assert
            Assert.IsTrue(
                adr.Name == "Адрес без названия" &&
                adr.Street == "Улица не указана" &&
                adr.HouseNumber == 1
                );
        }

        [DataTestMethod]
        [DataRow("", "", -10)]
        [DataRow(" ", " ", 10)]
        [DataRow("  ", "Улица", -14)]
        [DataRow("   ", "Улица", 15)]
        [DataRow("Название", "", -10)]
        [DataRow("Название", " ", 10)]
        [DataRow("Название", "Улица", -100)]
        [DataRow("Название", "Улица", 50)]
        public void DataConstruct(string dataName, string dataSt, int dataHNum)
        {
            //Arrange
            Address adr;
            string name = "Адрес без названия", st = "Улица не указана";
            int hss = 1;

            if (!String.IsNullOrWhiteSpace(dataName)) name = dataName;
            if (!String.IsNullOrWhiteSpace(dataSt)) st = dataSt;
            if (dataHNum > 0) hss = dataHNum;

            //Act
            adr = new Address(dataName, dataSt, dataHNum);

            //Assert
            Assert.IsTrue(
                adr.Name == name &&
                adr.Street == st &&
                adr.HouseNumber == hss
                );
        }

        [DataTestMethod]
        [DataRow(" ", -50)]
        [DataRow(" ", 20)]
        [DataRow("Change", -50)]
        [DataRow("Change", 20)]
        public void ChangeFields(string dataSt, int dataNum)
        {
            //Arrange
            Address adr = new Address();

            string st = String.IsNullOrWhiteSpace(dataSt) ? "Улица не указана" : dataSt;
            int num = dataNum >= 1 ? dataNum : 1;

            //Act
            adr.Street = dataSt;
            adr.HouseNumber = dataNum;

            Assert.IsTrue(
                adr.Street == st &&
                adr.HouseNumber == num
                );
        }
    }

    [TestClass]
    public class CloneTest
    {
        [TestMethod]
        public void ClonePlace()
        {
            //Arrange
            Place place = new Place("Место");

            //Act
            Place clone = (Place)place.Clone();

            //Assert
            Assert.IsTrue(clone.Name == $"{place.Name}");
        }

        [TestMethod]
        public void CloneRegion()
        {
            //Arrange
            Region region = new Region("Регион", 1000);

            //Act
            Region clone = (Region)region.Clone();

            //Assert
            Assert.IsTrue(clone.Name == $"{region.Name}" && clone.Population == region.Population);
        }

        [TestMethod]
        public void CloneCity()
        {
            //Arrange
            City city = new City("Город", 10, 5, new Address());

            //Act
            City clone = (City)city.Clone();

            //Assert
            Assert.AreEqual(city, clone);
        }

        [TestMethod]
        public void CloneAddress()
        {
            //Arrange
            Address address = new Address("Адрес", "Пушкина", 17);

            //Act
            Address clone = (Address)address.Clone();

            //Assert
            Assert.IsTrue(clone.Name == $"{address.Name}" &&
                clone.Street == address.Street && clone.HouseNumber == address.HouseNumber);
        }

        [TestMethod]
        public void ShallowCopy()
        {
            //Arrange
            Address test = new Address("Тестовый адрес", "Ленина", 17);
            City source = new City("Город", 50, 10, test);

            //Act
            City clone = (City)source.ShallowCopy();

            //Assert
            Assert.AreSame(test, clone.CopyAddress);
        }

        [TestMethod]
        public void Clone()
        {
            //Arrange
            Address test = new Address("Тестовый адрес", "Ленина", 17);
            City source = new City("Город", 50, 10, test);

            //Act
            City clone = (City)source.Clone();

            //Assert
            Assert.AreNotSame(test, clone.CopyAddress);
        }
    }
}
