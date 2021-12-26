using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М")]
        [TestCase(1, "", "", "", "", "")]
        public void TestClient(int idClient, string phone, string name, string surname, string patronyomic, string sex)
        {
            try
            {
                //arrange
                var client = new Client(idClient, phone, name, surname, patronyomic, sex);

                //act
                var result = client.ToString();
                //Assert
                Assert.AreEqual($"{surname},{name},{patronyomic},{sex},{phone}", result);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Test]
        [TestCase(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")]
        [TestCase(1, 0, "", "", "", "", "")]
        public void TestStaff(int idStaff, decimal salary, string position, string name, string surname, string patronyomic, string sex)
        {
            try
            {
                //arrange
                var staff = new Staff(idStaff, salary, position, name, surname, patronyomic, sex);

                //act
                var result = staff.ToString();
                //Assert
                Assert.AreEqual($"{surname}, {name}, {patronyomic}, {sex}, {position}, {salary}", result);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Test]
        [TestCase("a7j8k9h2", "Honda NSX", "Red", 6000000)]
        [TestCase("", "", "", 0)]
        public void TestCar(string vin, string model, string color, decimal price)
        {
            try
            {
                //arrange
                var car = new Car(vin, model, color, price);

                //act
                var result = car.ToString();
                //Assert
                Assert.AreEqual($"{vin}, {model}, {color}, {price}", result);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void TestSell()
        {
            //arrange
            var sell = new Sell(new Car("a7j8k9h2", "Honda NSX", "Red", 6000000), new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")
            , new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М"), 1, new System.DateTime(2021, 12, 11));

            //act
            var result = sell.ToString();
            //Assert
            Assert.AreEqual($"Продавец:{new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")} " +
                $"Покупатель:{new Client(1,"89622461234","Дмитрий","Антонов","Игоревич","М")} " +
                $"Машина:{new Car("a7j8k9h2", "Honda NSX", "Red", 6000000)} " +
                $"Договор:{1}, {new System.DateTime(2021, 12, 11)}", result);
        }

        [Test]
        public void TestSellNull()
        {
            try
            {
                //arrange
                var sell = new Sell(new Car("", "", "", 0),new Staff(1, 0, "", "", "", "", ""),new Client(1, "", "", "", "", ""),
                    1, new System.DateTime(2021, 12, 11));
                //act
                var result = sell.ToString();
                //assert
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }
    }
}