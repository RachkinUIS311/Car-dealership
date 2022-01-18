namespace ORM.Tests
{
    using Core;
    using NUnit.Framework;
    using FluentNHibernate.Testing;

    [TestFixture]
    internal class SellMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var sell = new Sell(new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000), new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М")
            , new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М"), 1, new System.DateTime(2021, 12, 11));

            // act & assert
            new PersistenceSpecification<Sell>(this.Session)
                .VerifyTheMappings(sell);
        }
    }
}
