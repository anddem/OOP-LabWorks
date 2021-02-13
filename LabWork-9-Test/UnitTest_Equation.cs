using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork_9;

namespace LabWork_9_Test
{
    struct Roots //Структура для тестирования вычисления корней
    {
        public double fRoot;
        public double sRoot;

        public Roots(double fR, double sR)
        {
            (fRoot, sRoot) = (fR, sR);
        }
    }

    [TestClass]
    public class UnitTest_Equation
    {
        #region Тестирование инкремента и декремента
        [TestMethod]
        public void ZeroAfterIncrement_Test()
        { //Тест отмены инкремента если коэффициент а становится равен 0
            //Arrange
            Equation expected = new Equation(-1, 1, 1);
            Equation actual = new Equation(-1, 1, 1);

            //Act
            actual++;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZeroAfterDecrement_Test()
        { //Тест отмены декремента если коэффициент а становится равным 0
            //Arrange
            Equation expected = new Equation(1, 1, 1);
            Equation actual = new Equation(1, 1, 1);

            //Act
            actual--;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Increment_Test()
        { //Тест инкремента коэффициентов
            //Arrange
            Equation expected = new Equation(5, 1.75, -9);
            Equation actual = new Equation(4, 0.75, -10);

            //Act
            actual++;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decrement_Test()
        { //Тест декремента коэффициентов
            //Arrange
            Equation expected = new Equation(5, 1.75, -9);
            Equation actual = new Equation(6, 2.75, -8);

            //Act
            actual--;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Тестирование получения корней
        [TestMethod]
        public void TrueHaveRoots_Test_1()
        { //Тест свойства существования корней если уравнение имеет корни
            //Arrange
            Equation expected = new Equation();

            //Act
            bool haveRoots = expected.HaveRoots;

            //Assert
            Assert.IsTrue(haveRoots);
        }

        [TestMethod]
        public void TrueHaveRoots_Test_2()
        { //Тест свойства существования корней если уравенение имеет корни
            //Arrange
            Equation expected = new Equation(1, 4, 4);

            //Act
            bool haveRoots = expected.HaveRoots;

            //Assert
            Assert.IsTrue(haveRoots);
        }

        [TestMethod]
        public void FalseHaveRoots_Test()
        { //Тест свойства существования корней если уравнение не имеет корней
            //Arrange
            Equation expected = new Equation(10, 0, 5);

            //Act
            bool haveRoots = expected.HaveRoots;

            //Assert
            Assert.IsFalse(haveRoots);
        }
        #endregion

        #region Тестирование оператора сравнения
        [TestMethod]
        public void Equal_Test_1()
        { //Тест перегрузки операции сравнения
            Equation expected1 = new Equation();
            Equation expected2 = new Equation();

            Assert.IsTrue(expected1 == expected2);
        }

        [TestMethod]
        public void Equal_Test_2()
        { //Тест перегрузки операции сравнения
            Equation expected1 = new Equation(5.89, 7.90, -5);
            Equation expected2 = new Equation(5.89, 7.90, -5);

            Assert.IsTrue(expected1 == expected2);
        }

        [TestMethod]
        public void NotEqual_Test()
        { //Тест перегрузки операции сравнения
            Equation expected1 = new Equation(56, 25, -5);
            Equation expected2 = new Equation();

            Assert.IsTrue(expected1 != expected2);
        }
        #endregion

        #region Тестирование вычисления корней
        [TestMethod]
        public void Roots_Test_1()
        { //Тест вычисления корней
            //Arrange
            Roots expected = new Roots(-2, -2);
            Equation test = new Equation(1, 4, 4);

            //Act
            test.Roots(out double fR, out double sR);

            //Assert
            Assert.AreEqual(expected, new Roots(fR, sR));
        }

        [TestMethod]
        public void Roots_Test_2()
        { //Тест вычисления корней
            //Arrange
            Roots expected = new Roots(0, 0);
            Equation test = new Equation();

            //Act
            test.Roots(out double fR, out double sR);

            //Assert
            Assert.AreEqual(expected, new Roots(fR, sR));
        }

        [TestMethod]
        public void Roots_Test_3()
        { //Тест вычисления корней
            //Arrange
            Roots expected = new Roots(0, 0);
            Equation test = new Equation(10, 0, 5);

            //Act
            test.Roots(out double fR, out double sR);

            //Assert
            Assert.AreEqual(expected, new Roots(fR, sR));
        }

        [TestMethod]
        public void StaticRoots_Test()
        { //Тестирование статического метода
            //Assert
            Roots expected = new Roots(-2, -2);
            Equation test = new Equation(1, 4, 4);

            //Act
            Equation.Roots(test, out double fR, out double sR);

            //Assert
            Assert.AreEqual(expected, new Roots(fR, sR));
        }
        #endregion

        [TestMethod]
        public void ImplicitDouble_Test()
        {
            //Arrange
            double expected = -2;
            Equation eq = new Equation(1, 4, 4);

            //Act
            double test = eq;

            //Assert
            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void ExplicitBool_Test()
        {
            //Arrange
            bool expected = true;
            Equation eq = new Equation();

            //Act
            bool test = (bool)eq;

            //Assert
            Assert.AreEqual(expected, test);
        }
    }
}
