using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Tests
{
    using Core;
    using NUnit.Framework;
    using ORM.Repositories;

    [TestFixture]
    internal class CarRepoTests : BaseMapTests
    {
        [Test]
        public void GetByTitle_ValidData_Success()
        {
            // arrange
            var repo = new CarRepository(this.Session);

            var car = new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000);

            // act
            repo.Save(car);
            var result = repo.GetByModel("Honda NSX");

            // assert
            Assert.AreEqual(car.Model, result.Model);
        }

        public void Save_ValidData_Success()
        {
            // arrange
            var repo = new CarRepository(this.Session);

            var car = new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000);

            // act & assert
            Assert.IsTrue(repo.Save(car));
        }
    }
}

