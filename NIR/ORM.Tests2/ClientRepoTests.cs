namespace ORM.Tests
{
    using Core;
    using NUnit.Framework;
    using ORM.Repositories;

    [TestFixture]
    internal class ClientRepoTests : BaseMapTests
    {
        [Test]
        public void GetByTitle_ValidData_Success()
        {
            // arrange
            var repo = new ClientRepository(this.Session);

            var client = new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М");

            // act
            repo.Save(client);
            var result = repo.GetBySurname("Антонов");

            // assert
            Assert.AreEqual(client.Surname, result.Surname);
        }

        public void Save_ValidData_Success()
        {
            // arrange
            var repo = new ClientRepository(this.Session);

            var client = new Client(1, "89622461234", "Дмитрий", "Антонов", "Игоревич", "М");

            // act & assert
            Assert.IsTrue(repo.Save(client));
        }
    }
}
