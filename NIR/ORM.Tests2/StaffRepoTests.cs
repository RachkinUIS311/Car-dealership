namespace ORM.Tests
{
    using Core;
    using NUnit.Framework;
    using ORM.Repositories;

    [TestFixture]
    internal class StaffRepoTests : BaseMapTests
    {
        [Test]
        public void GetByTitle_ValidData_Success()
        {
            // arrange
            var repo = new StaffRepository(this.Session);

            var staff = new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М");

            // act
            repo.Save(staff);
            var result = repo.GetBySurname("Газанов");

            // assert
            Assert.AreEqual(staff.Surname, result.Surname);
        }

        public void Save_ValidData_Success()
        {
            // arrange
            var repo = new StaffRepository(this.Session);

            var staff = new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М");

            // act & assert
            Assert.IsTrue(repo.Save(staff));
        }
    }
}
