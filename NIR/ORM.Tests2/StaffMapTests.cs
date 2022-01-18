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
    internal class StaffMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var staff = new Staff(1, 40000, "Менеджер", "Олег", "Газанов", "Васильев", "М");

            // act & assert
            new PersistenceSpecification<Staff>(this.Session)
                .VerifyTheMappings(staff);
        }
    }
}
