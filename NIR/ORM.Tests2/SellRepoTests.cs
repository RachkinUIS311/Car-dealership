namespace ORM.Tests
{
    using Core;
    using NUnit.Framework;
    using ORM.Repositories;
    using System;

    [TestFixture]
    internal class SellRepoTests : BaseMapTests
    {
        [Test]
        public void GetByTitle_ValidData_Success()
        {
            // arrange
            var repo = new SellRepository(this.Session);
            var sell = new Sell(new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000), new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")
            , new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М"), 1, new System.DateTime(2021, 12, 11));

            // act
            repo.Save(sell);
            var result = repo.Get(1);

            // assert
            Assert.AreEqual(sell.SellNumber, result.SellNumber);
        }

        public void Save_ValidData_Success()
        {
            // arrange
            var repo = new SellRepository(this.Session);
            var sell = new Sell(new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000), new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")
            , new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М"), 1, new System.DateTime(2021, 12, 11));
            // act & assert
            Assert.IsTrue(repo.Save(sell));
        }
    }
}
