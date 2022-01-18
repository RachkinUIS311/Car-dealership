using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Tests
{
    using FluentNHibernate.Testing;
    using Core;
    using NUnit.Framework;

    [TestFixture]
    internal class CarMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var car = new Car(2, "a7j8k9h2", "Honda NSX", "Red", 6000000);

            // act & assert
            new PersistenceSpecification<Car>(this.Session)
                .VerifyTheMappings(car);
        }
    }
}
